//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Enums;
using HF_API.Results;
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
        public virtual void AddResultParameters()
        {
            Parameters.Add("tid", true);
            Parameters.Add("fid", true);
            Parameters.Add("subject", true);
            Parameters.Add("prefix", true);
            Parameters.Add("icon", true);
            Parameters.Add("poll", true);
            Parameters.Add("uid", true);
            Parameters.Add("username", true);
            Parameters.Add("dateline", true);
            Parameters.Add("firstpost", true);
            Parameters.Add("lastpost", true);
            Parameters.Add("lastposter", true);
            Parameters.Add("lastposteruid", true);
            Parameters.Add("views", true);
            Parameters.Add("numreplies", true);
            Parameters.Add("closed", true);
            Parameters.Add("sticky", true);
            Parameters.Add("bestpid", true);
        }

    }
}

#endregion
