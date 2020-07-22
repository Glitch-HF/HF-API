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
    internal partial class PostRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Posts;

        /// <summary>
        /// Gets the post from the specified post id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="postId">The post id.</param>
        public static PostResult Get(HttpClient client, int postId)
        {
            var request = new PostRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_pid", postId);
            request.AddResultParameters();
            return request.ProcessRequest<PostResult>(client);
        }

        /// <summary>
        /// Gets the posts from the specified thread id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="threadId">The thread id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static PostResult[] SearchByThreadId(HttpClient client, int threadId, int page = 1, int perPage = 1)
        {
            var request = new PostRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_tid", threadId);
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
            return request.ProcessMultiRequest<PostResult>(client);
        }

        /// <summary>
        /// Searches all the posts made by the specified user.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="page">The page number.</param>
        /// <param name="perPage">The number of results per page.</param>
        public static PostResult[] SearchByUserId(HttpClient client, int userId, int page = 1, int perPage = 1)
        {
            var request = new PostRequest();
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
            return request.ProcessMultiRequest<PostResult>(client);
        }

        /// <summary>
        /// Creates a new post in the specified thread with the current token user as the author.
        /// Requires <see cref="APIPermission.POSTSWRITE" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="forumId">The thread id.</param>
        /// <param name="message">The message to post.</param>
        public static PostResult Create(HttpClient client, int forumId, string message)
        {
            var request = new PostRequest();
            request.Type = RequestType.Write;
            request.Parameters.Add("_tid", forumId);
            request.Parameters.Add("_message", message);
            request.AddResultParameters();
            return request.ProcessRequest<PostResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        internal override Dictionary<string, object> AddResultParameters()
        {
            var newParams = new List<KeyValuePair<string, object>>();
            newParams.Add(AddResultParameter<long>("pid", true));
            newParams.Add(AddResultParameter<int>("tid", true));
            newParams.Add(AddResultParameter<int>("uid", true));
            newParams.Add(AddResultParameter<int>("fid", true));
            newParams.Add(AddResultParameter<DateTime>("dateline", true));
            newParams.Add(AddResultParameter<string>("message", true));
            newParams.Add(AddResultParameter<string>("subject", true));
            newParams.Add(AddResultParameter<int>("edituid", true));
            newParams.Add(AddResultParameter<DateTime>("edittime", true));
            newParams.Add(AddResultParameter<string>("editreason", true));
            newParams.Add(AddResultParameter<UserResult>("author", true));
            return newParams.ToDictionary(_ => _.Key, _ => _.Value);
        }

    }
}

#endregion
