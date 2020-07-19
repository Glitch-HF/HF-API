//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Results;
using System;
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
        public static ThreadResult[] SearchByUserId(HttpClient client, int userId, int page, int perPage)
        {
            var request = new ThreadRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_uid", userId);
            request.Parameters.Add("_page", page);
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
        protected override void AddResultParameters()
        {
            AddResultParameter<int>("tid", true);
            AddResultParameter<int>("fid", true);
            AddResultParameter<string>("subject", true);
            AddResultParameter<int>("prefix", true);
            AddResultParameter<int>("icon", true);
            AddResultParameter<int>("poll", true);
            AddResultParameter<int>("uid", true);
            AddResultParameter<string>("username", true);
            AddResultParameter<DateTime>("dateline", true);
            AddResultParameter<long>("firstpost", true);
            AddResultParameter<DateTime>("lastpost", true);
            AddResultParameter<string>("lastposter", true);
            AddResultParameter<int>("lastposteruid", true);
            AddResultParameter<int>("views", true);
            AddResultParameter<int>("numreplies", true);
            AddResultParameter<bool>("closed", true);
            AddResultParameter<bool>("sticky", true);
            AddResultParameter<int>("bestpid", true);
        }

    }
}

#endregion
