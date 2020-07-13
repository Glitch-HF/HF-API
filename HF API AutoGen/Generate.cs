using System;
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
                sourcePath = Path.Combine(Environment.CurrentDirectory, args[0].Split('=')[1]);

                var assembly = Assembly.GetExecutingAssembly();
                var endpointResource = assembly.GetManifestResourceNames().FirstOrDefault(name => name.ToLower().Contains("endpoints.xml"));
                if (string.IsNullOrEmpty(endpointResource))
                {
                    throw new Exception("Could not find embedded resource 'endpoints.xml'");
                }

                var doc = XDocument.Load(assembly.GetManifestResourceStream(endpointResource));
                GenerateRequestFiles(doc, "reads", sourcePath);
                GenerateRequestFiles(doc, "writes", sourcePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to generate request files. Make sure the the path is set in the program arguments and that endpoints.xml is set to embedded.");
                Console.WriteLine(ex.ToString());
            }
        }

        static void GenerateRequestFiles(XDocument doc, string type, string sourcePath)
        {
            var sb = new StringBuilder();

            var requestSet = doc.Root.Element(type);
            var requestPath = requestSet.Attribute("path").Value;
            var requestInherit = requestSet.Attribute("inherit").Value;
            var sourceNamespace = $"HF_API.Requests.{requestPath}";

            sourcePath = Path.Combine(sourcePath, requestPath, "Generated");
            if (Directory.Exists(sourcePath))
            {
                Directory.Delete(sourcePath, true);
            }
            Directory.CreateDirectory(sourcePath);

            foreach (var request in requestSet.Descendants("request"))
            {
                var requestClass = request.Attribute("class").Value;
                var requestAsk = request.Attribute("ask").Value;
                var requestPermissions = request.Attribute("permissions").Value;
                var classPath = Path.Combine(sourcePath, requestClass + ".Generated.cs");
                var requestDesc = request.Descendants("parameters");

                var classUsings = (request.Attribute("using")?.Value ?? "").Split(",").Where(use => !string.IsNullOrWhiteSpace(use)).Select(use => $"using {use.Trim().Trim(';')};").ToList();
                classUsings.Add("using System.Collections.Generic;");
                if (requestDesc.Any(req => req.Descendants("parameter").Any(para => para.Attribute("min") != null)))
                {
                    classUsings.Add("using System;");
                }

                sb.Append($@"//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

{string.Join(Environment.NewLine, classUsings)}

namespace {sourceNamespace}
{{
    internal partial class {requestClass} : {requestInherit}
    {{
        protected override string RequestId => ""{requestAsk}"";

        protected override Dictionary<string, object> RequestParameters {{ get; }}
");

                foreach (var parameterSet in requestDesc)
                {
                    bool.TryParse(parameterSet.Attribute("require")?.Value ?? "false", out bool setRequired);

                    var parameterSetDesc = parameterSet.Descendants("parameter");

                    sb.Append($@"
        public {requestClass}({string.Join(", ", parameterSetDesc.Where(par => bool.TryParse(par.Attribute("const")?.Value ?? "false", out bool pConst) && !pConst).Select(par => {
                        var pName = par.Attribute("var")?.Value ?? par.Attribute("name").Value;
                        var pType = par.Attribute("type")?.Value ?? "";
                        var pDefault = pType?.ToLower() switch { "int" => "0", "string" => "null", _ => "default" };
                        bool.TryParse(par.Attribute("require")?.Value ?? setRequired.ToString(), out bool pRequired);
                        return $"{pType} {pName}{(pRequired ? "" : $" = {pDefault}")}";
                    }))})
        {{
            RequestParameters = new Dictionary<string, object>();");

                    foreach (var parameter in parameterSetDesc)
                    {
                        var parameterName = parameter.Attribute("name").Value;
                        var parameterVar = parameter.Attribute("var")?.Value ?? parameterName;
                        var parameterType = parameter.Attribute("type")?.Value ?? "object";
                        int.TryParse(parameter.Attribute("min")?.Value ?? "0", out int parameterMin);
                        bool.TryParse(parameter.Attribute("const")?.Value ?? "false", out bool parameterConst);
                        bool.TryParse(parameter.Attribute("require")?.Value ?? setRequired.ToString(), out bool parameterRequired);
                        var parameterValue = parameter.Attribute("value")?.Value;
                        parameterValue = parameterValue != null ? '"' + parameterValue + '"' : parameterType.ToLower() switch
                        {
                            "int" => parameterVar,
                            "string" => parameterVar,
                            _ => $"{parameterVar}.ToString()"
                        };

                        if (parameterConst)
                        {
                            sb.Append($@"
            RequestParameters.Add(""{parameterName}"", {parameterValue});");
                        }
                        else
                        {
                            if (parameterRequired)
                            {
                                sb.Append($@"
            RequestParameters.Add(""{parameterName}"", {parameterValue});");
                            }
                            else
                            {
                                var condition = (parameterType.ToLower()) switch
                                {
                                    "int" => $"{parameterVar} > 0",
                                    "string" => $"!string.IsNullOrEmpty({parameterVar})",
                                    _ => $"{parameterVar} != default"
                                };

                                sb.Append($@"
            if ({condition})
            {{
                RequestParameters.Add(""{parameterName}"", {parameterValue});
            }}");
                            }

                            if(parameterMin > 0)
                            {
                                sb.Append($@"
            if ({parameterVar} < {parameterMin})
            {{
                throw new ArgumentException(""{parameterName} cannot be less than {parameterMin}"", nameof({parameterVar}));
            }}");
                            }
                        }
                    }

                    sb.Append(@"
        }");
                }

                foreach (var resultSet in request.Descendants("results"))
                {
                    var resultSetDesc = resultSet.Descendants("result");
                    var resultSetPermissions = resultSet.Attribute("permissions")?.Value;
                    foreach (var result in resultSetDesc)
                    {
                        var resultPermissions = result.Attribute("permissions")?.Value ?? resultSetPermissions;
                    }
                }

                sb.AppendLine(@"
    }
}

#endregion");

                File.WriteAllText(classPath, sb.ToString());
                sb.Clear();
            }
        }
    }
}
