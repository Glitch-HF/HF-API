namespace HF_API.Enums
{
    /// <summary>
    /// Defines a scope of permissions available with the given API/Token.
    /// </summary>
    public enum APIPermission
    {
        /// <summary>
        /// Basic Info: Read
        /// </summary>
        BASIC,
        /// <summary>
        /// Advanced Info: Read
        /// </summary>
        ADV,
        /// <summary>
        /// Posts: Read
        /// </summary>
        POSTS,
        /// <summary>
        /// Users: Read
        /// </summary>
        USERS,
        /// <summary>
        /// Bytes: Read
        /// </summary>
        BYTES,
        /// <summary>
        /// Contracts: Read
        /// </summary>
        CONTRACTS,
        /// <summary>
        /// Basic Info: Read & Write
        /// </summary>
        BASICWRITE,
        /// <summary>
        /// Advanced Info: Read & Write
        /// </summary>
        ADVWRITE,
        /// <summary>
        /// Posts: Read & Write
        /// </summary>
        POSTSWRITE,
        /// <summary>
        /// Bytes: Read & Write
        /// </summary>
        BYTESWRITE,
        /// <summary>
        /// Contracts: Read & Write
        /// </summary>
        CONTRACTSWRITE
    }
}
