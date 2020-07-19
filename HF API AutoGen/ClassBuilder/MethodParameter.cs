namespace HF_API_AutoGen
{
    internal struct MethodParameter
    {
        /// <summary>
        /// The parameter name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The parameter type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The parameter description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The default, if any.
        /// </summary>
        public string Default { get; set; }
    }
}
