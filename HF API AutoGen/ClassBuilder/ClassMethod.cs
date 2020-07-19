namespace HF_API_AutoGen
{
    internal struct ClassMethod
    {
        /// <summary>
        /// The method name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The method type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The method summary lines.
        /// </summary>
        public string[] Summary { get; set; }

        /// <summary>
        /// Set to true to hide with the new keyword.
        /// </summary>
        public bool HideBase { get; set; }

        /// <summary>
        /// Set to true to hide with the new keyword.
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// The method's parameters.
        /// </summary>
        public MethodParameter[] Parameters { get; set; }

        /// <summary>
        /// The block statements in this method.
        /// </summary>
        public BlockStatement[] BlockStatements { get; set; }
    }
}
