namespace HF_API_AutoGen
{
    /// <summary>
    /// Defines a method block statement.
    /// </summary>
    internal class BlockStatement
    {
        /// <summary>
        /// The statement expression (could also be a condition for conditional types).
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// The indentation level of this statement.
        /// </summary>
        public virtual int Indentation { get; set; } = 0;

        /// <summary>
        /// Returns spaces based on the specified indentation.
        /// </summary>
        protected string Tab => new string(' ', 4 * Indentation);

        /// <summary>
        /// Constructs a new <see cref="BlockStatement"/>.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="indentation">The indentation level of the statement.</param>
        public BlockStatement(string expression, int indentation = 0)
        {
            Expression = expression;
            Indentation = indentation;
        }

        /// <summary>
        /// Generate the statement string.
        /// </summary>
        /// <returns>The string of the statement.</returns>
        public virtual string Generate() => $"{Tab}{Expression}";

        /// <summary>
        /// Implicit operator for simple expression statements.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public static implicit operator BlockStatement(string expression) => new BlockStatement(expression);
    }
}
