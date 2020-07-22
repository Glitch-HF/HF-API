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
    internal partial class ByteTransactionRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Bytes;

        /// <summary>
        /// Gets the byte transaction from the specified transaction id.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="transactionId">The byte transaction id.</param>
        public static ByteTransactionResult Get(HttpClient client, int transactionId)
        {
            var request = new ByteTransactionRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_id", transactionId);
            request.AddResultParameters();
            return request.ProcessRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Searches all the byte transactions involving the specified user.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static ByteTransactionResult[] SearchByUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new ByteTransactionRequest();
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
            return request.ProcessMultiRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Searches all the byte transactions sent from the specified user.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static ByteTransactionResult[] SearchByFromUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new ByteTransactionRequest();
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
            return request.ProcessMultiRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Searches all the byte transactions sent to the specified user.
        /// Requires <see cref="APIPermission.BYTES" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static ByteTransactionResult[] SearchByToUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new ByteTransactionRequest();
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
            return request.ProcessMultiRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Donates bytes from the current token user to the specified user.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="forumId">The user id to donate the bytes to.</param>
        /// <param name="amount">The amount of bytes to send.</param>
        /// <param name="reason">The message to post.</param>
        /// <param name="postId">The post id to link this donation to.</param>
        public static ByteTransactionResult Donate(HttpClient client, int forumId, decimal amount, string reason = null, long postId = 0)
        {
            var request = new ByteTransactionRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_uid", forumId);
            request.Parameters.Add("_amount", amount);
            if (reason != null)
            {
                request.Parameters.Add("_reason", reason);
            }
            if (postId != 0)
            {
                request.Parameters.Add("_pid", postId);
            }
            request.AddResultParameters();
            return request.ProcessRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Deposits the specified amount of bytes to the current token user's vault.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="amount">The amount of bytes to deposit.</param>
        public static ByteTransactionResult Deposit(HttpClient client, decimal amount)
        {
            var request = new ByteTransactionRequest();
            request.Type = RequestType.Write;
            if (amount < 100)
            {
                throw new ArgumentException("Parameter cannot be less than 100.", nameof(amount));
            }
            request.Parameters.Add("_deposit", amount);
            request.AddResultParameters();
            return request.ProcessRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Withdraws the specified amount of bytes from the current token user's vault.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="amount">The amount of bytes to withdraw.</param>
        public static ByteTransactionResult Withdraws(HttpClient client, decimal amount)
        {
            var request = new ByteTransactionRequest();
            request.Type = RequestType.Write;
            if (amount < 100)
            {
                throw new ArgumentException("Parameter cannot be less than 100.", nameof(amount));
            }
            request.Parameters.Add("_withdraw", amount);
            request.AddResultParameters();
            return request.ProcessRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Bumps the specified thread using the current token user's bytes.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="threadId">The id of the thread to bump.</param>
        public static ByteTransactionResult BumpThread(HttpClient client, int threadId)
        {
            var request = new ByteTransactionRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_bump", threadId);
            request.AddResultParameters();
            return request.ProcessRequest<ByteTransactionResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.Add(AddResultParameter<int>("id", true));
            newParams.Add(AddResultParameter<decimal>("amount", true));
            newParams.Add(AddResultParameter<DateTime>("dateline", true));
            newParams.Add(AddResultParameter<ByteTransactionType>("type", true));
            newParams.Add(AddResultParameter<string>("reason", true));
            newParams.Add(AddResultParameter<UserResult>("from", true));
            newParams.Add(AddResultParameter<UserResult>("to", true));
            newParams.Add(AddResultParameter<PostResult>("post", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
