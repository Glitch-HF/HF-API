namespace HF_API.Enums
{
    public enum ByteTransactionType
    {
        /// <summary>
        /// Unknown transactions, use '<see cref="ByteTransaction.Reason"/>' for detail.
        /// </summary>
        Unknown,
        /// <summary>
        /// bla - Games / Blackjack
        /// </summary>
        BlackJack,
        /// <summary>
        /// slo - Games / Slots
        /// </summary>
        Slots,
        /// <summary>
        /// don - Donation
        /// </summary>
        Donation,
        /// <summary>
        /// ltb - Games / Lottery
        /// </summary>
        Lotto,
        /// <summary>
        /// dci - Daily Check In
        /// </summary>
        CheckIn,
        /// <summary>
        /// qlp - Quick Love React
        /// </summary>
        QuickLove,
        /// <summary>
        /// cgp - Games / Crypto Game (Coin Purchase or Sale)
        /// </summary>
        CryptoGame,
        /// <summary>
        /// sig - Signature Space Purchase
        /// </summary>
        Signature,
        /// <summary>
        /// hip - Games / Hackúman (In-game Purchase)
        /// </summary>
        Hackúman,
        /// <summary>
        /// sbw - Games / Sportsbook (Wager)
        /// </summary>
        SportWager
    }
}
