namespace HF_API_AutoGen
{
    // <property name="avatardimensions" type="Size" var="AvatarDimensions" converter="AvatarSizeConverter" desc="The avatar dimensions." />
    internal struct ClassProperty
    {
        /// <summary>
        /// The property's JsonProperty Name.
        /// </summary>
        public string JsonName { get; set; }

        /// <summary>
        /// The property's Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The property's variable name.
        /// </summary>
        public string VariableName { get; set; }
        
        /// <summary>
        /// The JsonConverter to associate the property to.
        /// </summary>
        public string JsonConverter { get; set; }

        /// <summary>
        /// The property description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// If this is an override.
        /// </summary>
        public bool IsOverride { get; set; }

        /// <summary>
        /// The value to assign.
        /// </summary>
        public string Value { get; set; }
    }
}
