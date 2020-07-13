using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HF_API.Requests.Read
{
    /// <summary>
    /// Represents a read request to the HF API
    /// </summary>
    internal abstract class RequestRead : APIRequest
    {
        /// <summary>
        /// Returns the path for read requests.
        /// </summary>
        /// <returns>The path for read requests.</returns>
        protected override string Path => "read";

        /// <summary>
        /// The read parameters needed to post this request.
        /// </summary>
        /// <returns>The dictionary of parameters.</returns>
        protected override Dictionary<string, string> Parameters => new Dictionary<string, string>
        {
            { "asks", JsonConvert.SerializeObject(new Dictionary<string, Dictionary<string, object>> { { RequestId, RequestParameters } }) }
        };

        /// <summary>
        /// The id for the read request ('posts', 'threads', etc), used in the post.
        /// </summary>
        protected abstract string RequestId { get; }

        /// <summary>
        /// The parameters for this request.
        /// </summary>
        protected abstract Dictionary<string, object> RequestParameters { get; }
    }
}
