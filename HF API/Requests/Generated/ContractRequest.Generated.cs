//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HF_API.Requests
{
    internal partial class ContractRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Contracts;

        /// <summary>
        /// Gets the contract from the specified contract id.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The contract id.</param>
        public static ContractResult Get(HttpClient client, int contractId)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_cid", contractId);
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Searches all the contracts involving the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static ContractResult[] SearchByUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_uid", userId);
            if (page < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(page));
            }
            request.Parameters.Add("_page", page);
            if (perPage < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(perPage));
            }
            if (perPage > 3)
            {
                throw new ArgumentException("Parameter cannot be greater than 3.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<ContractResult>(client);
        }

        /// <summary>
        /// Creates a new contract initiated by the current token user with the specified parameters.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The id of the other user to begin the contract with.</param>
        /// <param name="position">The current user's position in the contract.</param>
        /// <param name="terms">The terms of the contract.</param>
        /// <param name="yourProduct">The user's product.</param>
        /// <param name="yourCurrency">The user's currency.</param>
        /// <param name="yourAmount">The user's amount (and currency if ContractCurrency.OTHER).</param>
        /// <param name="theirProduct">The other user's product.</param>
        /// <param name="theirCurrency">The other user's currency.</param>
        /// <param name="theirAmount">The other user's amount (and currency if ContractCurrency.OTHER).</param>
        /// <param name="threadId">The id of the thread to link this contract to.</param>
        /// <param name="middlemanId">The user id of the middleman.</param>
        /// <param name="timeoutDays">The time (in days) that the contract will expire.</param>
        /// <param name="isPublic">Whether this is a public contract.</param>
        /// <param name="paymentAddress">The payment address.</param>
        public static ContractResult Create(HttpClient client, int userId, ContractPosition position, string terms, string yourProduct = null, ContractCurrency yourCurrency = ContractCurrency.NONE, string yourAmount = null, string theirProduct = null, ContractCurrency theirCurrency = ContractCurrency.NONE, string theirAmount = null, int threadId = 0, int middlemanId = 0, int timeoutDays = 0, bool isPublic = false, string paymentAddress = null)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "new");
            request.Parameters.Add("_uid", userId);
            request.Parameters.Add("_position", position);
            request.Parameters.Add("_terms", terms);
            if (yourProduct != null)
            {
                request.Parameters.Add("_yourproduct", yourProduct);
            }
            if (yourCurrency != ContractCurrency.NONE)
            {
                request.Parameters.Add("_yourcurrency", yourCurrency.ToString());
            }
            if (yourAmount != null)
            {
                request.Parameters.Add("_youramount", yourAmount);
            }
            if (theirProduct != null)
            {
                request.Parameters.Add("_theirproduct", theirProduct);
            }
            if (theirCurrency != ContractCurrency.NONE)
            {
                request.Parameters.Add("_theircurrency", theirCurrency.ToString());
            }
            if (theirAmount != null)
            {
                request.Parameters.Add("_theiramount", theirAmount);
            }
            if (threadId != 0)
            {
                request.Parameters.Add("_tid", threadId);
            }
            if (middlemanId != 0)
            {
                request.Parameters.Add("_muid", middlemanId);
            }
            if (timeoutDays != 0)
            {
                request.Parameters.Add("_timeout", timeoutDays);
            }
            if (isPublic != false)
            {
                request.Parameters.Add("_public", "yes");
            }
            if (paymentAddress != null)
            {
                request.Parameters.Add("_address", paymentAddress);
            }
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Undo a newly created contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        public static ContractResult Undo(HttpClient client, int contractId)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "undo");
            request.Parameters.Add("_cid", contractId);
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Deny a new contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        public static ContractResult Deny(HttpClient client, int contractId)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "deny");
            request.Parameters.Add("_cid", contractId);
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Approve a new contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        /// <param name="paymentAddress">The payment address.</param>
        public static ContractResult Approve(HttpClient client, int contractId, string paymentAddress = null)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "approve");
            request.Parameters.Add("_cid", contractId);
            if (paymentAddress != null)
            {
                request.Parameters.Add("_address", paymentAddress);
            }
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Deny a contract as middleman.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        public static ContractResult MiddlemanDeny(HttpClient client, int contractId)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "middleman_deny");
            request.Parameters.Add("_cid", contractId);
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Approve a contract as middleman.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        public static ContractResult MiddlemanApprove(HttpClient client, int contractId)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "middleman_approve");
            request.Parameters.Add("_cid", contractId);
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Cancel as contract (spawned from contract template) as Vendor.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        public static ContractResult VendorCancel(HttpClient client, int contractId)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "vendor_cancel");
            request.Parameters.Add("_cid", contractId);
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Request cancel (requires both parties to cancel).
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        public static ContractResult Cancel(HttpClient client, int contractId)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "cancel");
            request.Parameters.Add("_cid", contractId);
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Mark a contract as complete.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The id of the contract.</param>
        /// <param name="txn">The transaction.</param>
        public static ContractResult Complete(HttpClient client, int contractId, string txn = null)
        {
            var request = new ContractRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_action", "complete");
            request.Parameters.Add("_cid", contractId);
            if (txn != null)
            {
                request.Parameters.Add("_txn", txn);
            }
            request.AddResultParameters();
            return request.ProcessRequest<ContractResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.Add(AddResultParameter<int>("cid", true));
            newParams.Add(AddResultParameter<DateTime>("dateline", true));
            newParams.Add(AddResultParameter<DateTime>("otherdateline", true));
            newParams.Add(AddResultParameter<bool>("public", true));
            newParams.Add(AddResultParameter<int>("timeout_days", true));
            newParams.Add(AddResultParameter<DateTime>("timeout", true));
            newParams.Add(AddResultParameter<string>("terms", true));
            newParams.Add(AddResultParameter<int>("tid", true));
            newParams.Add(AddResultParameter<ThreadResult>("thread", true));
            newParams.Add(AddResultParameter<int>("template_id", true));
            newParams.Add(AddResultParameter<bool>("cancelstatus", true));
            newParams.Add(AddResultParameter<ContractPosition>("type", true));
            newParams.Add(AddResultParameter<int>("inituid", true));
            newParams.Add(AddResultParameter<UserResult>("inituser", true));
            newParams.Add(AddResultParameter<int>("otheruid", true));
            newParams.Add(AddResultParameter<UserResult>("otheruser", true));
            newParams.Add(AddResultParameter<int>("muid", true));
            newParams.Add(AddResultParameter<UserResult>("escrow", true));
            newParams.Add(AddResultParameter<string>("iprice", true));
            newParams.Add(AddResultParameter<string>("oprice", true));
            newParams.Add(AddResultParameter<string>("icurrency", true));
            newParams.Add(AddResultParameter<string>("ocurrency", true));
            newParams.Add(AddResultParameter<string>("iaddress", true));
            newParams.Add(AddResultParameter<string>("oaddress", true));
            newParams.Add(AddResultParameter<string>("iproduct", true));
            newParams.Add(AddResultParameter<string>("oproduct", true));
            newParams.Add(AddResultParameter<DisputeResult>("idispute", true));
            newParams.Add(AddResultParameter<DisputeResult>("odispute", true));
            newParams.Add(AddResultParameter<BusinessRatingResult>("ibrating", true));
            newParams.Add(AddResultParameter<BusinessRatingResult>("obrating", true));
            newParams.Add(AddResultParameter<object>("status", true));
            newParams.Add(AddResultParameter<object>("istatus", true));
            newParams.Add(AddResultParameter<object>("ostatus", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
