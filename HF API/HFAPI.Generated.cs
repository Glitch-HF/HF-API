//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Requests;
using HF_API.Results;

namespace HF_API
{
    public partial class HFAPI
    {
        /// <summary>
        /// Reads the basic profile information from the current token session.
        /// Requires <see cref="APIPermission.BASIC" />
        /// <summary>
        public ProfileResult ProfileRead() => ProfileRequest.Read(Client);

        /// <summary>
        /// Reads the advanced profile information from the current token session.
        /// Requires <see cref="APIPermission.ADV" />
        /// <summary>
        public AdvancedProfileResult AdvancedProfileRead() => AdvancedProfileRequest.Read(Client);

        /// <summary>
        /// Gets the forum from the specified forum id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="forumId">The forum id.</param>
        public ForumResult ForumGet(int forumId) => ForumRequest.Get(Client, forumId);

        /// <summary>
        /// Gets the thread from the specified thread id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="threadId">The thread id.</param>
        public ThreadResult ThreadGet(int threadId) => ThreadRequest.Get(Client, threadId);

        /// <summary>
        /// Searches all the threads made by the specified user.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public ThreadResult[] ThreadSearchByUserId(int userId, int page = 1, int perPage = 1) => ThreadRequest.SearchByUserId(Client, userId, page, perPage);

        /// <summary>
        /// Creates a new thread in the specified forum with the current token user as the author.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="forumId">The forum id.</param>
        /// <param name="subject">The subject of the thread.</param>
        /// <param name="message">The message to post.</param>
        public ThreadResult ThreadCreate(int forumId, string subject, string message) => ThreadRequest.Create(Client, forumId, subject, message);

        /// <summary>
        /// Gets the post from the specified post id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="postId">The post id.</param>
        public PostResult PostGet(int postId) => PostRequest.Get(Client, postId);

        /// <summary>
        /// Gets the posts from the specified thread id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="threadId">The thread id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public PostResult[] PostSearchByThreadId(int threadId, int page = 1, int perPage = 1) => PostRequest.SearchByThreadId(Client, threadId, page, perPage);

        /// <summary>
        /// Searches all the posts made by the specified user.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public PostResult[] PostSearchByUserId(int userId, int page = 1, int perPage = 1) => PostRequest.SearchByUserId(Client, userId, page, perPage);

        /// <summary>
        /// Creates a new post in the specified thread with the current token user as the author.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="forumId">The thread id.</param>
        /// <param name="message">The message to post.</param>
        public PostResult PostCreate(int forumId, string message) => PostRequest.Create(Client, forumId, message);

        /// <summary>
        /// Gets the user from the specified user id.
        /// Requires <see cref="APIPermission.USERS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        public UserResult UserGet(int userId) => UserRequest.Get(Client, userId);

        /// <summary>
        /// Gets the byte transaction from the specified transaction id.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="transactionId">The byte transaction id.</param>
        public ByteTransactionResult ByteTransactionGet(int transactionId) => ByteTransactionRequest.Get(Client, transactionId);

        /// <summary>
        /// Searches all the byte transactions involving the specified user.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public ByteTransactionResult[] ByteTransactionSearchByUserId(int userId, int page = 1, int perPage = 1) => ByteTransactionRequest.SearchByUserId(Client, userId, page, perPage);

        /// <summary>
        /// Searches all the byte transactions sent from the specified user.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public ByteTransactionResult[] ByteTransactionSearchByFromUserId(int userId, int page = 1, int perPage = 1) => ByteTransactionRequest.SearchByFromUserId(Client, userId, page, perPage);

        /// <summary>
        /// Searches all the byte transactions sent to the specified user.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public ByteTransactionResult[] ByteTransactionSearchByToUserId(int userId, int page = 1, int perPage = 1) => ByteTransactionRequest.SearchByToUserId(Client, userId, page, perPage);

        /// <summary>
        /// Donates bytes from the current token user to the specified user.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="forumId">The user id to donate the bytes to.</param>
        /// <param name="amount">The amount of bytes to send.</param>
        /// <param name="reason">The message to post.</param>
        /// <param name="postId">The post id to link this donation to.</param>
        public ByteTransactionResult ByteTransactionDonate(int forumId, decimal amount, string reason = null, long postId = 0) => ByteTransactionRequest.Donate(Client, forumId, amount, reason, postId);

        /// <summary>
        /// Deposits the specified amount of bytes to the current token user's vault.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="amount">The amount of bytes to deposit.</param>
        public ByteTransactionResult ByteTransactionDeposit(decimal amount) => ByteTransactionRequest.Deposit(Client, amount);

        /// <summary>
        /// Withdraws the specified amount of bytes from the current token user's vault.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="amount">The amount of bytes to withdraw.</param>
        public ByteTransactionResult ByteTransactionWithdraws(decimal amount) => ByteTransactionRequest.Withdraws(Client, amount);

        /// <summary>
        /// Bumps the specified thread using the current token user's bytes.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="threadId">The id of the thread to bump.</param>
        public ByteTransactionResult ByteTransactionBumpThread(int threadId) => ByteTransactionRequest.BumpThread(Client, threadId);

        /// <summary>
        /// Gets the contract from the specified contract id.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId">The contract id.</param>
        public ContractResult ContractGet(int contractId) => ContractRequest.Get(Client, contractId);

        /// <summary>
        /// Searches all the contracts involving the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public ContractResult[] ContractSearchByUserId(int userId, int page = 1, int perPage = 1) => ContractRequest.SearchByUserId(Client, userId, page, perPage);

        /// <summary>
        /// Creates a new contract initiated by the current token user with the specified parameters.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId"></param>
        /// <param name="position"></param>
        /// <param name="terms"></param>
        /// <param name="yourProduct"></param>
        /// <param name="yourCurrency"></param>
        /// <param name="yourAmount"></param>
        /// <param name="theirProduct"></param>
        /// <param name="theirCurrency"></param>
        /// <param name="theirAmount"></param>
        /// <param name="threadId"></param>
        /// <param name="middlemanId"></param>
        /// <param name="timeoutDays"></param>
        /// <param name="isPublic"></param>
        /// <param name="paymentAddress"></param>
        public ContractResult ContractCreate(int userId, ContractPosition position, string terms, string yourProduct = null, ContractCurrency yourCurrency = ContractCurrency.NONE, string yourAmount = null, string theirProduct = null, ContractCurrency theirCurrency = ContractCurrency.NONE, string theirAmount = null, int threadId = 0, int middlemanId = 0, int timeoutDays = 0, bool isPublic = false, string paymentAddress = null) => ContractRequest.Create(Client, userId, position, terms, yourProduct, yourCurrency, yourAmount, theirProduct, theirCurrency, theirAmount, threadId, middlemanId, timeoutDays, isPublic, paymentAddress);

        /// <summary>
        /// Undo a newly created contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        public ContractResult ContractUndo(int contractId) => ContractRequest.Undo(Client, contractId);

        /// <summary>
        /// Deny a new contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        public ContractResult ContractDeny(int contractId) => ContractRequest.Deny(Client, contractId);

        /// <summary>
        /// Approve a new contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        /// <param name="paymentAddress"></param>
        public ContractResult ContractApprove(int contractId, string paymentAddress = null) => ContractRequest.Approve(Client, contractId, paymentAddress);

        /// <summary>
        /// Deny a contract as middleman.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        public ContractResult ContractMiddlemanDeny(int contractId) => ContractRequest.MiddlemanDeny(Client, contractId);

        /// <summary>
        /// Approve a contract as middleman.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        public ContractResult ContractMiddlemanApprove(int contractId) => ContractRequest.MiddlemanApprove(Client, contractId);

        /// <summary>
        /// Cancel as contract (spawned from contract template) as Vendor.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        public ContractResult ContractVendorCancel(int contractId) => ContractRequest.VendorCancel(Client, contractId);

        /// <summary>
        /// Request cancel (requires both parties to cancel).
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        public ContractResult ContractCancel(int contractId) => ContractRequest.Cancel(Client, contractId);

        /// <summary>
        /// Mark a contract as complete.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId"></param>
        /// <param name="txn"></param>
        public ContractResult ContractComplete(int contractId, string txn = null) => ContractRequest.Complete(Client, contractId, txn);

        /// <summary>
        /// Gets the dispute from the specified dispute id.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="disputeId">The dispute id.</param>
        public DisputeResult DisputeGet(int disputeId) => DisputeRequest.Get(Client, disputeId);

        /// <summary>
        /// Searches all the disputes involving the specified contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public DisputeResult[] DisputeSearchByContractId(int contractId, int page = 1, int perPage = 1) => DisputeRequest.SearchByContractId(Client, contractId, page, perPage);

        /// <summary>
        /// Searches all the disputes involving the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public DisputeResult[] DisputeSearchByUserId(int userId, int page = 1, int perPage = 1) => DisputeRequest.SearchByUserId(Client, userId, page, perPage);

        /// <summary>
        /// Searches all the disputes initiated by the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId">The claimant user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public DisputeResult[] DisputeSearchByClaimantId(int userId, int page = 1, int perPage = 1) => DisputeRequest.SearchByClaimantId(Client, userId, page, perPage);

        /// <summary>
        /// Searches all the disputes received by the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId">The defendant user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public DisputeResult[] DisputeSearchByDefendantId(int userId, int page = 1, int perPage = 1) => DisputeRequest.SearchByDefendantId(Client, userId, page, perPage);

        /// <summary>
        /// Gets the business rating from the specified transaction id.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="transactionId">The byte transaction id.</param>
        public BusinessRatingResult BusinessRatingGet(int transactionId) => BusinessRatingRequest.Get(Client, transactionId);

        /// <summary>
        /// Searches all the business ratings involving the specified contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="contractId">The contract id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public BusinessRatingResult[] BusinessRatingSearchByContractId(int contractId, int page = 1, int perPage = 1) => BusinessRatingRequest.SearchByContractId(Client, contractId, page, perPage);

        /// <summary>
        /// Searches all the business ratings involving the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public BusinessRatingResult[] BusinessRatingSearchByUserId(int userId, int page = 1, int perPage = 1) => BusinessRatingRequest.SearchByUserId(Client, userId, page, perPage);

        /// <summary>
        /// Searches all the business ratings given from the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public BusinessRatingResult[] BusinessRatingSearchByFromUserId(int userId, int page = 1, int perPage = 1) => BusinessRatingRequest.SearchByFromUserId(Client, userId, page, perPage);

        /// <summary>
        /// Searches all the business ratings given to the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public BusinessRatingResult[] BusinessRatingSearchByToUserId(int userId, int page = 1, int perPage = 1) => BusinessRatingRequest.SearchByToUserId(Client, userId, page, perPage);

    }
}

#endregion
