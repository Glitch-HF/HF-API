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
    internal partial class ForumRequest : APIRequest
    {
        /// <inheritdoc />
        protected override RequestAsk Ask => RequestAsk.Forums;

        /// <summary>
        /// Gets the forum from the specified forum id.
        /// Requires <see cref="APIPermission.POSTS" />
        /// <summary>
        /// <param name="client">The client to use to process this request.</param>
        /// <param name="forumId">The forum id.</param>
        public static ForumResult Get(HttpClient client, int forumId)
        {
            var request = new ForumRequest();
            request.Type = RequestType.Read;
            request.Parameters.Add("_fid", forumId);
            request.AddResultParameters();
            return request.ProcessRequest<ForumResult>(client);
        }

        /// <summary>
        /// Adds the result parameters to the list.
        /// <summary>
        public virtual void AddResultParameters()
        {
            Parameters.Add("fid", true);
            Parameters.Add("name", true);
            Parameters.Add("description", true);
            Parameters.Add("type", true);
        }

    }
}

#endregion
