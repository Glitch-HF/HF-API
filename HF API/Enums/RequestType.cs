namespace HF_API.Enums
{
    /// <summary>
    /// Defines a type of request
    /// </summary>
    internal enum RequestType
    {
        /// <summary>
        /// For the /read endpoint
        /// </summary>
        Read,
        /// <summary>
        /// For the /write endpoint
        /// </summary>
        Write,
        /// <summary>
        /// For the /authorize endpoint
        /// </summary>
        Authorize,
    }
}
