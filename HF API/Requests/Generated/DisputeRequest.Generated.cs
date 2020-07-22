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
    internal partial class DisputeRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Disputes;

        /// <summary>
        /// Gets the dispute from the specified dispute id.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="disputeId">The dispute id.</param>
        public static DisputeResult Get(HttpClient client, int disputeId)
        {
            var request = new DisputeRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_cdid", disputeId);
            request.AddResultParameters();
            return request.ProcessRequest<DisputeResult>(client);
        }

        /// <summary>
        /// Searches all the disputes involving the specified contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The contract id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static DisputeResult[] SearchByContractId(HttpClient client, int contractId, int page = 1, int perPage = 1)
        {
            var request = new DisputeRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_cid", contractId);
            if (page < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(page));
            }
            request.Parameters.Add("_page", page);
            if (perPage < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(perPage));
            }
            if (perPage > 7)
            {
                throw new ArgumentException("Parameter cannot be greater than 7.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<DisputeResult>(client);
        }

        /// <summary>
        /// Searches all the disputes involving the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static DisputeResult[] SearchByUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new DisputeRequest();
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
            if (perPage > 7)
            {
                throw new ArgumentException("Parameter cannot be greater than 7.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<DisputeResult>(client);
        }

        /// <summary>
        /// Searches all the disputes initiated by the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The claimant user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static DisputeResult[] SearchByClaimantId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new DisputeRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_claimantuid", userId);
            if (page < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(page));
            }
            request.Parameters.Add("_page", page);
            if (perPage < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(perPage));
            }
            if (perPage > 7)
            {
                throw new ArgumentException("Parameter cannot be greater than 7.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<DisputeResult>(client);
        }

        /// <summary>
        /// Searches all the disputes received by the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The defendant user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static DisputeResult[] SearchByDefendantId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new DisputeRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_defendantuid", userId);
            if (page < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(page));
            }
            request.Parameters.Add("_page", page);
            if (perPage < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(perPage));
            }
            if (perPage > 7)
            {
                throw new ArgumentException("Parameter cannot be greater than 7.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<DisputeResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.Add(AddResultParameter<int>("cdid", true));
            newParams.Add(AddResultParameter<DateTime>("dateline", true));
            newParams.Add(AddResultParameter<int>("dispute_tid", true));
            newParams.Add(AddResultParameter<ThreadResult>("dispute_thread", true));
            newParams.Add(AddResultParameter<int>("contractid", true));
            newParams.Add(AddResultParameter<ContractResult>("contract", true));
            newParams.Add(AddResultParameter<int>("claimantuid", true));
            newParams.Add(AddResultParameter<UserResult>("claimant", true));
            newParams.Add(AddResultParameter<string>("claimantnotes", true));
            newParams.Add(AddResultParameter<int>("defendantuid", true));
            newParams.Add(AddResultParameter<UserResult>("defendant", true));
            newParams.Add(AddResultParameter<string>("defendantnotes", true));
            newParams.Add(AddResultParameter<object>("status", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
