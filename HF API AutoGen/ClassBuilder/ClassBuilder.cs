using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HF_API_AutoGen
{
    /// <summary>
    /// For helping build class files.
    /// </summary>
    internal class ClassBuilder
    {
        /// <summary>
        /// The backing <see cref="StringBuilder"/>
        /// </summary>
        private readonly StringBuilder builder = new StringBuilder();

        /// <summary>
        /// The current tab index (used while building).
        /// </summary>
        private int tabIndex = 0;

        /// <summary>
        /// The number of spaces to a tab.
        /// </summary>
        private const int TabSpacing = 4;

        /// <summary>
        /// Creates the tab from the index and spacing.
        /// </summary>
        private string Tab => new string(' ', tabIndex * TabSpacing);

        /// <summary>
        /// The name of the class.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The name of the base class to inherit.
        /// </summary>
        private string BaseClass { get; }

        /// <summary>
        /// The class modifier(s).
        /// </summary>
        private string Modifier { get; }

        /// <summary>
        /// The using statements.
        /// </summary>
        private List<string> Usings { get; } = new List<string>();

        /// <summary>
        /// The class namespace.
        /// </summary>
        private string Namespace { get; }

        /// <summary>
        /// The class properties.
        /// </summary>
        private List<ClassProperty> Properties { get; } = new List<ClassProperty>();

        /// <summary>
        /// The class methods.
        /// </summary>
        private List<ClassMethod> Methods { get; } = new List<ClassMethod>();

        /// <summary>
        /// Create a new <see cref="ClassBuilder"/> instance with the specified name and base class name to inherit.
        /// </summary>
        /// <param name="name">The name of the class.</param>
        /// <param name="namespace">The class namespace.</param>
        /// <param name="baseClass">The base class name to inherit.</param>
        public ClassBuilder(string name, string @namespace, string baseClass = null, string modifier = "public")
        {
            Name = name;
            Namespace = @namespace;
            BaseClass = baseClass;
            Modifier = modifier;
        }

        /// <summary>
        /// Generates the class file and writes to the specified output path.
        /// </summary>
        /// <param name="outputPath">The output file path.</param>
        public void Generate(string outputPath)
        {
            GenerateBegin();
            GenerateUsings();
            GenerateHeader();
            GenerateProperties();
            GenerateMethods();
            GenerateEnd();

            File.WriteAllText(outputPath, builder.ToString());
            builder.Clear();
        }

        /// <summary>
        /// Adds the comma-delimited usings to the class.
        /// </summary>
        /// <param name="usings">The comma-delimited list of usings.</param>
        public void AddUsings(params string[] usings) => Usings.AddRange(usings.SelectMany(use => use?.Split(',') ?? Array.Empty<string>()));

        /// <summary>
        /// Adds the property to the class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="jsonProperty"></param>
        /// <param name="jsonConverter"></param>
        public void AddProperty(string name, string type, string description, string jsonProperty, string jsonConverter, string value = null) => Properties.Add(new ClassProperty
        {
            VariableName = name,
            Type = type,
            JsonName = jsonProperty,
            JsonConverter = jsonConverter,
            Description = description,
            Value = value
        });

        /// <summary>
        /// Adds an override property to the class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void OverrideProperty(string name, string type, string value) => Properties.Add(new ClassProperty
        {
            VariableName = name,
            Type = type,
            IsOverride = true,
            Value = value
        });

        /// <summary>
        /// Adds a method to the class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="parameters"></param>
        /// <param name="statements"></param>
        /// <param name="hideBase"></param>
        public void AddMethod(string name, string type, string[] summary, List<MethodParameter> parameters, List<BlockStatement> statements, string modifiers = "public static") => Methods.Add(new ClassMethod
        {
            Name = name,
            Type = type,
            Summary = summary,
            Parameters = parameters.ToArray(),
            BlockStatements = statements.ToArray(),
            Modifiers = modifiers
        });

        #region Generate Helpers

        /// <summary>
        /// Begins the generation with the 
        /// </summary>
        private void GenerateBegin()
        {
            builder.AppendLine("//////////////////////////////////////////////");
            builder.AppendLine("/// This class is automatically generated. ///");
            builder.AppendLine("/// Do not attempt to modify as it will be ///");
            builder.AppendLine("/// overwritten on the next build attempt. ///");
            builder.AppendLine("//////////////////////////////////////////////");
            builder.AppendLine();
            builder.AppendLine("#region Auto-Generated Code");
            builder.AppendLine();
        }

        /// <summary>
        /// Generate the using statements
        /// </summary>
        private void GenerateUsings()
        {
            foreach (string name in Usings.Distinct().OrderBy(_ => _))
            {
                builder.AppendLine($"using {name};");
            }
            if (Usings.Any())
            {
                builder.AppendLine();
            }
        }

        /// <summary>
        /// Generate the header information for the class
        /// </summary>
        private void GenerateHeader()
        {
            builder.AppendLine($"{Tab}namespace {Namespace}");
            builder.AppendLine($"{Tab}{{");
            Indent(1);
            builder.AppendLine($"{Tab}{Modifier} partial class {Name}{(BaseClass == null ? "" : $" : {BaseClass}")}");
            builder.AppendLine($"{Tab}{{");
            Indent(1);
        }

        /// <summary>
        /// Generates the class properties
        /// </summary>
        private void GenerateProperties()
        {
            foreach (var property in Properties)
            {
                if (property.IsOverride)
                {
                    builder.AppendLine($"{Tab}/// <inheritdoc />");
                    builder.Append($"{Tab}protected override {property.Type} {property.VariableName} => {property.Value};");
                }
                else
                {
                    builder.AppendLine($"{Tab}/// <summary>");
                    builder.AppendLine($"{Tab}/// {property.Description}");
                    builder.AppendLine($"{Tab}/// <summary>");

                    if (!string.IsNullOrWhiteSpace(property.JsonName))
                    {
                        string attribute = $"[JsonProperty(\"{property.JsonName}\")";
                        if (!string.IsNullOrWhiteSpace(property.JsonConverter))
                        {
                            attribute += $", JsonConverter(typeof({property.JsonConverter}))";
                        }
                        attribute += "]";
                        builder.AppendLine($"{Tab}{attribute}");
                    }
                    builder.Append($"{Tab}public {property.Type} {property.VariableName} {{ get; set; }}");
                    if (!string.IsNullOrWhiteSpace(property.Value))
                    {
                        builder.Append($" = {property.Value};");
                    }
                }
                builder.AppendLine();
                builder.AppendLine();
            }
        }

        /// <summary>
        /// Generates the class methods
        /// </summary>
        private void GenerateMethods()
        {
            foreach (var method in Methods)
            {
                var paramList = new List<string>();
                builder.AppendLine($"{Tab}/// <summary>");
                foreach (var summaryLine in method.Summary)
                {
                    builder.AppendLine($"{Tab}/// {summaryLine}");
                }
                builder.AppendLine($"{Tab}/// <summary>");
                foreach (var parameter in method.Parameters ?? Array.Empty<MethodParameter>())
                {
                    builder.AppendLine($"{Tab}/// <param name=\"{parameter.Name}\">{parameter.Description}</param>");
                    paramList.Add($"{parameter.Type} {parameter.Name}{(string.IsNullOrWhiteSpace(parameter.Default) ? "" : $" = {parameter.Default}")}");
                }
                builder.Append($"{Tab}{method.Modifiers} {method.Type} {method.Name}({string.Join(", ", paramList)})");

                var firstBlock = method.BlockStatements.FirstOrDefault();
                if (method.BlockStatements.Length == 1 && firstBlock.GetType() == typeof(BlockStatement))
                {
                    firstBlock.Indentation = 0;
                    var statement = firstBlock.Generate();
                    statement = statement.ToLower().StartsWith("return ") ? statement["return ".Length..] : statement;
                    builder.Append($" => {statement}");
                    builder.AppendLine();
                }
                else
                {
                    builder.AppendLine();
                    builder.AppendLine($"{Tab}{{");
                    Indent(1);
                    foreach (var block in method.BlockStatements)
                    {
                        block.Indentation = tabIndex;
                        builder.AppendLine(block.Generate());
                    }
                    Indent(-1);
                    builder.AppendLine($"{Tab}}}");
                }
                builder.AppendLine();
            }
        }

        /// <summary>
        /// Closes out the class file
        /// </summary>
        private void GenerateEnd()
        {
            Indent(-1);
            builder.AppendLine($"{Tab}}}");
            Indent(-1);
            builder.AppendLine($"{Tab}}}");
            builder.AppendLine();
            builder.AppendLine("#endregion");
        }

        /// <summary>
        /// Indents the current tab in the direction specified.
        /// </summary>
        /// <param name="direction">The direction to index (1, 0, -1).</param>
        private void Indent(int direction) => tabIndex += direction;

        #endregion
    }
}
