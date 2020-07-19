namespace HF_API.Enums
{
    /// <summary>
    /// Defines currency types to that can be specified for contracts.
    /// </summary>
    public enum ContractCurrency
    {
        /// <summary>
        /// Default value (valid for <see cref="ContractPosition.Trading"/> and <see cref="ContractPosition.Vouch_Copy"/> only)
        /// </summary>
        NONE,
        /// <summary>
        /// Amazon GC
        /// </summary>
        AGC,
        /// <summary>
        /// Apple Pay
        /// </summary>
        APPLE,
        /// <summary>
        /// Bitcoin Cash
        /// </summary>
        BCH,
        /// <summary>
        /// Bitcoin
        /// </summary>
        BTC,
        /// <summary>
        /// Cash App
        /// </summary>
        CASHAPP,
        /// <summary>
        /// Dash
        /// </summary>
        DASH,
        /// <summary>
        /// Ethereum
        /// </summary>
        ETH,
        /// <summary>
        /// Litecoin
        /// </summary>
        LTC,
        /// <summary>
        /// Paypal
        /// </summary>
        PAYPAL,
        /// <summary>
        /// Perfect Money
        /// </summary>
        PERFECT,
        /// <summary>
        /// USD (Non Crypto)
        /// </summary>
        USD,
        /// <summary>
        /// Venmo
        /// </summary>
        VENMO,
        /// <summary>
        /// Monero
        /// </summary>
        XMR,
        /// <summary>
        /// Ripple
        /// </summary>
        XRP,
        /// <summary>
        /// Zelle
        /// </summary>
        ZELLE,
        /// <summary>
        /// Other
        /// </summary>
        OTHER,
    }
}