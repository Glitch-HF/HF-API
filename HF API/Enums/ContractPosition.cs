namespace HF_API.Enums
{
    /// <summary>
    /// Defines the position of the user initiating a contract.
    /// </summary>
    public enum ContractPosition
    {
        /// <summary>
        /// When the user is receiving a product and providing currency
        /// </summary>
        Buying,
        /// <summary>
        /// When the user is providing a product and receiving currency
        /// </summary>
        Selling,
        /// <summary>
        /// When both users are exchanging a currency
        /// </summary>
        Exchanging,
        /// <summary>
        /// When both users are trading a product
        /// </summary>
        Trading,
        /// <summary>
        /// When the user is offering a copy of a product for a vouch (must have a sales thread attached).
        /// </summary>
        Vouch_Copy
    }
}
