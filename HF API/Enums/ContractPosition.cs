namespace HF_API.Enums
{
    /// <summary>
    /// Defines the position of the user initiating a contract.
    /// </summary>
    public enum ContractPosition
    {
        /// <summary>
        /// Unknown / Unsupported
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// When the user is receiving a product and providing currency
        /// </summary>
        Buying = 1,
        /// <summary>
        /// When the user is providing a product and receiving currency
        /// </summary>
        Selling = 2,
        /// <summary>
        /// When both users are exchanging a currency
        /// </summary>
        Exchanging = 3,
        /// <summary>
        /// When both users are trading a product
        /// </summary>
        Trading = 4,
        /// <summary>
        /// When the user is offering a copy of a product for a vouch (must have a sales thread attached).
        /// </summary>
        Vouch_Copy = 5
    }
}
