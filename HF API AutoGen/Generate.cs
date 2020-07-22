using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace HF_API_AutoGen
{
    class Generate
    {
        static void Main(string[] args)
        {
            string sourcePath;
            try
            {
                if (args.Length == 0 || !(args[0]?.ToLower().Contains("path=") ?? false))
                {
                    throw new Exception(@"Argument for 'path' must be specified, eg- ""path=C:\source""");
                }
                sourcePath = Path.Combine(Environment.CurrentDirectory, args[0].Split('=')[1].Trim('"').Trim());

                var assembly = Assembly.GetExecutingAssembly();
                var endpointResource = assembly.GetManifestResourceNames().FirstOrDefault(name => name.ToLower().Contains("endpoints.xml"));
                if (string.IsNullOrEmpty(endpointResource))
                {
                    throw new Exception("Could not find embedded resource 'endpoints.xml'");
                }

                var doc = XDocument.Load(assembly.GetManifestResourceStream(endpointResource), LoadOptions.SetLineInfo);
                GenerateRequestFiles(doc, sourcePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to generate request files. Make sure the the path is set in the program arguments and that endpoints.xml is set to embedded.");
                Console.WriteLine(ex.ToString());
            }
        }

        static void GenerateRequestFiles(XDocument doc, string sourcePath)
        {
            string requestPath = Path.Combine(sourcePath, "Requests", "Generated");
            string resultPath = Path.Combine(sourcePath, "Results", "Generated");

            string[] customConverters = Directory.EnumerateFiles(Path.Combine(sourcePath, "Converters"), "*.cs").Select(Path.GetFileNameWithoutExtension).ToArray();
            string[] customEnums = Directory.EnumerateFiles(Path.Combine(sourcePath, "Enums"), "*.cs").Select(Path.GetFileNameWithoutExtension).ToArray();
            string[] resultTypes = doc.Root.Elements("request").Select(request => $"{request.Attribute("class").Value}Result").ToArray();

            var mainApiClass = new ClassBuilder("HFAPI", "HF_API");
            mainApiClass.AddUsings("HF_API.Results", "HF_API.Requests", "HF_API.Enums");

            // Clean up existing auto-generated files and create directory if it doesn't exist
            foreach (string path in new[] { requestPath, resultPath })
            {
                if (Directory.Exists(path))
                {
                    Directory.GetFiles(path, "*.Generated.cs", SearchOption.AllDirectories).ToList().ForEach(file => File.Delete(file));
                }
                else
                {
                    Directory.CreateDirectory(path);
                }
            }

            // Iterate through each request node and generate files
            foreach (var request in doc.Root.Elements("request"))
            {
                string className = request.Attribute("class").Value;
                Log($"Request type: {className}");

                string ask = request.Attribute("ask")?.Value;
                string inherits = request.Attribute("inherits")?.Value;

                var requestClass = new ClassBuilder($"{className}Request", "HF_API.Requests", $"{inherits ?? "API"}Request", "internal");
                requestClass.AddUsings("HF_API.Enums", "HF_API.Results", "System.Net.Http", "System.Collections.Generic", "System.Linq");
                if (!string.IsNullOrWhiteSpace(ask))
                {
                    requestClass.OverrideProperty("Ask", "RequestAsk", $"RequestAsk.{ask}");
                }

                bool hasBase = !string.IsNullOrWhiteSpace(inherits);
                if (!hasBase && string.IsNullOrWhiteSpace(ask))
                {
                    throw new Exception("Endpoints.xml is invalid, must specify either ask or inherits attribute for request class: " + className);
                }

                var resultClass = new ClassBuilder($"{className}Result", "HF_API.Results", $"{inherits ?? "API"}Result");
                resultClass.AddUsings("HF_API.Requests", "Newtonsoft.Json", "System", "System.Collections.Generic");

                var properties = request.Descendants("property").ToList();
                int resultPropertyCount = 0;
                foreach(var prop in properties)
                {
                    string resultProp = $"{prop.Attribute("type").Value}Result";
                    if (resultTypes.Contains(resultProp))
                    {
                        resultPropertyCount++;
                    }
                }
                int maxPerPage = 30 / Math.Max(1, resultPropertyCount);

                foreach (var method in request.Elements("method"))
                {
                    string methodName = method.Attribute("name").Value;

                    var methodParams = new List<MethodParameter>()
                    {
                        new MethodParameter
                        {
                            Name = "client",
                            Type = "HttpClient",
                            Description = "The client to use to process this request."
                        }
                    };

                    var parameters = method.Elements("param").ToList();
                    if (method.Attribute("pages")?.Value?.ToLower() == "true")
                    {
                        parameters.AddRange(new[]
                        {
                            new XElement("param",
                                new XAttribute("name", "_page"),
                                new XAttribute("type", "int"),
                                new XAttribute("var", "page"),
                                new XAttribute("min", "1"),
                                new XAttribute("default", "1"),
                                new XAttribute("desc", "The page number.")
                            ),
                            new XElement("param",
                                new XAttribute("name", "_perpage"),
                                new XAttribute("type", "int"),
                                new XAttribute("var", "perPage"),
                                new XAttribute("min", "1"),
                                new XAttribute("max", maxPerPage),
                                new XAttribute("default", "1"),
                                new XAttribute("desc", "The number of results per page.")
                            )
                        });
                    }

                    var requestConstructor = $"new {requestClass.Name}()";
                    var methodStatements = new List<BlockStatement>()
                    {
                        $"var request = {requestConstructor};",
                        $"request.Type = RequestType.{method.Attribute("apiType").Value.Trim()};",
                    };

                    foreach (var param in parameters)
                    {
                        try
                        {
                            if (param.Attribute("const")?.Value.ToLower().Trim() == "true")
                            {
                                methodStatements.Add($"request.Parameters.Add(\"{param.Attribute("name").Value}\", \"{param.Attribute("value").Value}\");");
                                continue;
                            }

                            string paramType = param.Attribute("type").Value;
                            string paramVar = param.Attribute("var").Value;
                            string paramDefault = param.Attribute("default")?.Value;

                            methodParams.Add(new MethodParameter
                            {
                                Name = paramVar,
                                Type = paramType,
                                Description = param.Attribute("desc")?.Value,
                                Default = paramDefault
                            });

                            if (int.TryParse(param.Attribute("min")?.Value ?? "", out int paramMin) && paramMin > 0)
                            {
                                requestClass.AddUsings("System");
                                methodStatements.Add(new BlockConditional($"{paramVar} < {paramMin}", $"throw new ArgumentException(\"Parameter cannot be less than {paramMin}.\", nameof({paramVar}));"));
                            }

                            if (int.TryParse(param.Attribute("max")?.Value ?? "", out int paramMax) && paramMax > 0)
                            {
                                requestClass.AddUsings("System");
                                methodStatements.Add(new BlockConditional($"{paramVar} > {paramMax}", $"throw new ArgumentException(\"Parameter cannot be greater than {paramMax}.\", nameof({paramVar}));"));
                            }

                            BlockStatement requestStatement = $"request.Parameters.Add(\"{param.Attribute("name").Value}\", {paramVar});";

                            string ifNotDefault = param.Attribute("ifNotDefault")?.Value;
                            if (ifNotDefault != null)
                            {
                                requestStatement = new BlockConditional($"{paramVar} != {paramDefault}", $"request.Parameters.Add(\"{param.Attribute("name").Value}\", {ifNotDefault});");
                            }

                            methodStatements.Add(requestStatement);
                        }
                        catch (Exception paramException)
                        {
                            int lineNumber = -1, linePosition = -1;
                            var propInfo = (IXmlLineInfo)param;
                            if (propInfo.HasLineInfo())
                            {
                                lineNumber = propInfo.LineNumber;
                                linePosition = propInfo.LinePosition;
                            }
                            throw new XmlException($"Issue found in endpoints.xml with property:{Environment.NewLine}{param.ToString()}", paramException, lineNumber, linePosition);
                        }
                    }

                    methodStatements.Add("request.AddResultParameters();");

                    bool multiResponse = (method.Attribute("multi")?.Value ?? "false").ToLower() == "true";
                    methodStatements.Add($"return request.Process{(multiResponse ? "Multi" : "")}Request<{resultClass.Name}>(client);");

                    string[] methodSummary = new[] { method.Attribute("desc").Value, $"Requires <see cref=\"APIPermission.{method.Attribute("scope").Value}\" />" };
                    string methodType = resultClass.Name + (multiResponse ? "[]" : "");
                    requestClass.AddMethod(
                        name: methodName,
                        summary: methodSummary,
                        type: methodType,
                        parameters: methodParams,
                        statements: methodStatements,
                        modifiers: $"public static{(hasBase ? " new" : "")}"
                    );

                    Log($"- [{method.Attribute("apiType").Value}] {resultClass.Name}{(multiResponse ? "[]" : "")} {className}{methodName}({string.Join(", ", methodParams.Skip(1).Select(param => $"{param.Type} {param.Name}"))})");

                    mainApiClass.AddMethod(
                        name: className + methodName,
                        summary: methodSummary,
                        type: methodType,
                        parameters: methodParams.Skip(1).ToList(),
                        statements: new List<BlockStatement>()
                        {
                            $"return {requestClass.Name}.{methodName}({string.Join(", ", new[] { "Client" }.Concat(methodParams.Skip(1).Select(param => param.Name)))});"
                        },
                        modifiers: "public"
                    );
                }

                List<string> processedNames = new List<string>();
                List<string> processedVarNames = new List<string>();
                foreach (var prop in properties)
                {
                    try
                    {
                        string propName = prop.Attribute("name").Value;
                        if (processedNames.Contains(propName.ToLower()))
                        {
                            throw new Exception($"Properties must have unique names, found duplicate '{propName}'");
                        }
                        processedNames.Add(propName.ToLower());

                        string propVarName = prop.Attribute("var").Value;
                        if (processedVarNames.Contains(propVarName.ToLower()))
                        {
                            throw new Exception($"Properties must have unique var names, found duplicate '{propVarName}'");
                        }
                        processedVarNames.Add(propVarName.ToLower());

                        string propType = GetPropType(prop, resultTypes);

                        string propConverter = null;
                        if (customEnums.Contains(propType))
                        {
                            resultClass.AddUsings("HF_API.Enums");
                            requestClass.AddUsings("HF_API.Enums");
                        }
                        else
                        {
                            switch (propType.ToLower())
                            {
                                case "datetime":
                                    propConverter = "UnixDateTimeConverter";
                                    resultClass.AddUsings("System");
                                    requestClass.AddUsings("System");
                                    break;

                                case "size":
                                    propConverter = "AvatarSizeConverter";
                                    resultClass.AddUsings("System.Drawing");
                                    requestClass.AddUsings("System.Drawing");
                                    break;

                                case "int[]":
                                    propConverter = "StringIntArrayConverter";
                                    break;

                                case "timespan":
                                    resultClass.AddUsings("System");
                                    requestClass.AddUsings("System");
                                    break;
                            }
                        }

                        if (string.IsNullOrEmpty(propConverter))
                        {
                            propConverter = customConverters.FirstOrDefault(converter => converter.ToLower() == $"{propType.ToLower()}converter");
                        }

                        if (!string.IsNullOrWhiteSpace(propConverter))
                        {
                            resultClass.AddUsings(customConverters.Contains(propConverter) ? $"HF_API.Converters" : "Newtonsoft.Json.Converters");
                        }

                        resultClass.AddProperty(
                            name: propVarName,
                            type: propType,
                            description: prop.Attribute("desc").Value,
                            jsonProperty: propName,
                            jsonConverter: propConverter
                        );
                    }
                    catch (Exception propertyException)
                    {
                        int lineNumber = -1, linePosition = -1;
                        var propInfo = (IXmlLineInfo)prop;
                        if (propInfo.HasLineInfo())
                        {
                            lineNumber = propInfo.LineNumber;
                            linePosition = propInfo.LinePosition;
                        }
                        throw new XmlException($"Issue found in endpoints.xml with property:{Environment.NewLine}{prop.ToString()}", propertyException, lineNumber, linePosition);
                    }
                }

                var addResultParametersStatements = new List<BlockStatement>();
                if (hasBase)
                {
                    addResultParametersStatements.Add("newParams.AddRange(base.AddResultParameters());");
                }

                addResultParametersStatements.AddRange(properties.Select(prop => new BlockStatement($"newParams.Add(AddResultParameter<{GetPropType(prop, resultTypes)}>(\"{prop.Attribute("name").Value}\", true));")));
                requestClass.AddMethod(
                    name: "AddResultParameters",
                    type: "Dictionary<string, object>",
                    summary: new[] { "Adds the result parameters to the list." },
                    parameters: new List<MethodParameter>(),
                    statements: new BlockStatement[]
                    {
                        "var newParams = new List<KeyValuePair<string, object>>();"
                    }.Concat(addResultParametersStatements).Concat(new BlockStatement[]
                    {
                        "return newParams.ToDictionary(_ => _.Key, _ => _.Value);"
                    }).ToList(),
                    modifiers: "internal override"
                );
                
                resultClass.AddMethod(
                    name: "GetResultParameters",
                    summary: new[] { $"Gets the result parameter set from a new <see cref=\"{requestClass.Name}\" /> instance." },
                    type: "Dictionary<string, object>",
                    parameters: Array.Empty<MethodParameter>().ToList(),
                    statements: new List<BlockStatement>
                    {
                        $"return (Activator.CreateInstance<{requestClass.Name}>() as APIRequest).AddResultParameters();",
                    },
                    modifiers: "internal override"
                );

                requestClass.Generate(Path.Combine(requestPath, $"{className}Request.Generated.cs"));
                resultClass.Generate(Path.Combine(resultPath, $"{className}Result.Generated.cs"));
            }

            mainApiClass.Generate(Path.Combine(sourcePath, $"HFAPI.Generated.cs"));
        }

        static string GetPropType(XElement prop, string[] resultTypes)
        {
            string propType = prop.Attribute("type").Value;
            if (resultTypes.Any(result => result == $"{propType}Result"))
            {
                propType = $"{propType}Result";
            }
            return propType;
        }

        static void Log(string message) => Console.WriteLine(message);
    }
}
