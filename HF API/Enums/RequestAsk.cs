namespace HF_API.Enums
{
    /// <summary>
    /// The request ask type.
    /// </summary>
    internal enum RequestAsk
    {
        /// <summary>
        /// Profile and Site Information (BASIC BASICWRITE ADV ADVWRITE)
        /// </summary>
        Me,
        /// <summary>
        /// Forum reading (POSTS)
        /// </summary>
        Forums,
        /// <summary>
        /// Thread reading and writing (POSTS POSTSWRITE)
        /// </summary>
        Threads,
        /// <summary>
        /// Post reading and writing (POSTS POSTSWRITE)
        /// </summary>
        Posts,
        /// <summary>
        /// Users reading (USERS)
        /// </summary>
        Users,
        /// <summary>
        /// Bytes reading and writing (BYTES BYTESWRITE)
        /// </summary>
        Bytes,
        /// <summary>
        /// Contracts reading and writing (CONTRACTS CONTRACTSWRITE)
        /// </summary>
        Contracts
    }
}
