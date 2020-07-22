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
    internal partial class BusinessRatingRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Bratings;

        /// <summary>
        /// Gets the business rating from the specified transaction id.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="transactionId">The byte transaction id.</param>
        public static BusinessRatingResult Get(HttpClient client, int transactionId)
        {
            var request = new BusinessRatingRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_crid", transactionId);
            request.AddResultParameters();
            return request.ProcessRequest<BusinessRatingResult>(client);
        }

        /// <summary>
        /// Searches all the business ratings involving the specified contract.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="contractId">The contract id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static BusinessRatingResult[] SearchByContractId(HttpClient client, int contractId, int page = 1, int perPage = 1)
        {
            var request = new BusinessRatingRequest();
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
            if (perPage > 10)
            {
                throw new ArgumentException("Parameter cannot be greater than 10.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<BusinessRatingResult>(client);
        }

        /// <summary>
        /// Searches all the business ratings involving the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static BusinessRatingResult[] SearchByUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new BusinessRatingRequest();
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
            if (perPage > 10)
            {
                throw new ArgumentException("Parameter cannot be greater than 10.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<BusinessRatingResult>(client);
        }

        /// <summary>
        /// Searches all the business ratings given from the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static BusinessRatingResult[] SearchByFromUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new BusinessRatingRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_from", userId);
            if (page < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(page));
            }
            request.Parameters.Add("_page", page);
            if (perPage < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(perPage));
            }
            if (perPage > 10)
            {
                throw new ArgumentException("Parameter cannot be greater than 10.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<BusinessRatingResult>(client);
        }

        /// <summary>
        /// Searches all the business ratings given to the specified user.
        /// Requires <see cref="APIPermission.CONTRACTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static BusinessRatingResult[] SearchByToUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new BusinessRatingRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_to", userId);
            if (page < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(page));
            }
            request.Parameters.Add("_page", page);
            if (perPage < 1)
            {
                throw new ArgumentException("Parameter cannot be less than 1.", nameof(perPage));
            }
            if (perPage > 10)
            {
                throw new ArgumentException("Parameter cannot be greater than 10.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<BusinessRatingResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.Add(AddResultParameter<int>("crid", true));
            newParams.Add(AddResultParameter<DateTime>("dateline", true));
            newParams.Add(AddResultParameter<int>("amount", true));
            newParams.Add(AddResultParameter<string>("message", true));
            newParams.Add(AddResultParameter<int>("contractid", true));
            newParams.Add(AddResultParameter<ContractResult>("contract", true));
            newParams.Add(AddResultParameter<int>("fromid", true));
            newParams.Add(AddResultParameter<UserResult>("from", true));
            newParams.Add(AddResultParameter<int>("toid", true));
            newParams.Add(AddResultParameter<UserResult>("to", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
