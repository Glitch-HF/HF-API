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
    internal partial class ThreadRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Threads;

        /// <summary>
        /// Gets the thread from the specified thread id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="threadId">The thread id.</param>
        public static ThreadResult Get(HttpClient client, int threadId)
        {
            var request = new ThreadRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_tid", threadId);
            request.AddResultParameters();
            return request.ProcessRequest<ThreadResult>(client);
        }

        /// <summary>
        /// Searches all the threads made by the specified user.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static ThreadResult[] SearchByUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new ThreadRequest();
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
            if (perPage > 30)
            {
                throw new ArgumentException("Parameter cannot be greater than 30.", nameof(perPage));
            }
            request.Parameters.Add("_perpage", perPage);
            request.AddResultParameters();
            return request.ProcessMultiRequest<ThreadResult>(client);
        }

        /// <summary>
        /// Creates a new thread in the specified forum with the current token user as the author.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="forumId">The forum id.</param>
        /// <param name="subject">The subject of the thread.</param>
        /// <param name="message">The message to post.</param>
        public static ThreadResult Create(HttpClient client, int forumId, string subject, string message)
        {
            var request = new ThreadRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_fid", forumId);
            request.Parameters.Add("_subject", subject);
            request.Parameters.Add("_message", message);
            request.AddResultParameters();
            return request.ProcessRequest<ThreadResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.Add(AddResultParameter<int>("tid", true));
            newParams.Add(AddResultParameter<int>("fid", true));
            newParams.Add(AddResultParameter<string>("subject", true));
            newParams.Add(AddResultParameter<int>("prefix", true));
            newParams.Add(AddResultParameter<int>("icon", true));
            newParams.Add(AddResultParameter<int>("poll", true));
            newParams.Add(AddResultParameter<int>("uid", true));
            newParams.Add(AddResultParameter<string>("username", true));
            newParams.Add(AddResultParameter<DateTime>("dateline", true));
            newParams.Add(AddResultParameter<PostResult>("firstpost", true));
            newParams.Add(AddResultParameter<DateTime>("lastpost", true));
            newParams.Add(AddResultParameter<string>("lastposter", true));
            newParams.Add(AddResultParameter<int>("lastposteruid", true));
            newParams.Add(AddResultParameter<int>("views", true));
            newParams.Add(AddResultParameter<int>("numreplies", true));
            newParams.Add(AddResultParameter<bool>("closed", true));
            newParams.Add(AddResultParameter<bool>("sticky", true));
            newParams.Add(AddResultParameter<int>("bestpid", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
