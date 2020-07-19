using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

                var doc = XDocument.Load(assembly.GetManifestResourceStream(endpointResource));
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

                string ask = request.Attribute("ask")?.Value;
                string inherits = request.Attribute("inherits")?.Value;


                var requestClass = new ClassBuilder($"{className}Request", "HF_API.Requests", $"{inherits ?? "API"}Request", "internal");
                requestClass.AddUsings("HF_API.Enums", "HF_API.Results", "System.Net.Http");
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
                resultClass.AddUsings("Newtonsoft.Json");

                var properties = request.Descendants("property");

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

                    var parameters = method.Elements("param");
                    var requestConstructor = $"new {requestClass.Name}()";
                    var methodStatements = new List<BlockStatement>()
                    {
                        $"var request = {requestConstructor};",
                        $"request.Type = RequestType.{method.Attribute("apiType").Value.Trim()};",
                    };

                    foreach (var param in parameters)
                    {
                        string paramVar = param.Attribute("var").Value;
                        string paramType = param.Attribute("type").Value;

                        methodParams.Add(new MethodParameter
                        {
                            Name = paramVar,
                            Type = paramType,
                            Description = param.Attribute("desc")?.Value,
                        });

                        methodStatements.Add($"request.Parameters.Add(\"{param.Attribute("name").Value}\", {paramVar});");
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

                var addResultParametersStatements = new List<BlockStatement>();
                if (hasBase)
                {
                    addResultParametersStatements.Add("base.AddResultParameters();");
                }
                addResultParametersStatements.AddRange(properties.Select(prop => new BlockStatement($"AddResultParameter<{prop.Attribute("type").Value}>(\"{prop.Attribute("name").Value}\", true);")));
                requestClass.AddMethod(
                    name: "AddResultParameters",
                    type: "void",
                    summary: new[] { "Adds the result parameters to the list." },
                    parameters: new List<MethodParameter>(),
                    statements: addResultParametersStatements.ToList(),
                    modifiers: $"protected override"
                );

                foreach (var prop in properties)
                {
                    string propConverter = prop.Attribute("converter")?.Value;
                    if (!string.IsNullOrWhiteSpace(propConverter))
                    {
                        resultClass.AddUsings(customConverters.Contains(propConverter) ? $"HF_API.Converters" : "Newtonsoft.Json.Converters");
                    }

                    string propType = prop.Attribute("type").Value;
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
                                resultClass.AddUsings("System");
                                requestClass.AddUsings("System");
                                break;
                            case "size":
                                resultClass.AddUsings("System.Drawing");
                                requestClass.AddUsings("System.Drawing");
                                break;
                        }
                    }

                    string propVarName = prop.Attribute("var").Value;
                    resultClass.AddProperty(
                        name: propVarName,
                        type: propType,
                        description: prop.Attribute("desc").Value,
                        jsonProperty: prop.Attribute("name").Value,
                        jsonConverter: propConverter
                    );
                }

                requestClass.Generate(Path.Combine(requestPath, $"{className}Request.Generated.cs"));
                resultClass.Generate(Path.Combine(resultPath, $"{className}Result.Generated.cs"));
            }

            mainApiClass.Generate(Path.Combine(sourcePath, $"HFAPI.Generated.cs"));
        }
    }
}