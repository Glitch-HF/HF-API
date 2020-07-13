using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HF_API.Requests.Write
{
    /// <summary>
    /// Represents a write request to the HF API
    /// </summary>
    internal abstract class RequestWrite : APIRequest
    {
        /// <summary>
        /// Returns the path for write requests.
        /// </summary>
        /// <returns>The path for write requests.</returns>
        protected override string Path => "write";

        /// <summary>
        /// The read parameters needed to post this request.
        /// </summary>
        /// <returns>The dictionary of parameters.</returns>
        protected override Dictionary<string, string> Parameters => new Dictionary<string, string>
        {
            { "asks", JsonConvert.SerializeObject(new Dictionary<string, Dictionary<string, object>> { { RequestId, RequestParameters } }) }
        };

        /// <summary>
        /// The id for the write request ('posts', 'threads', etc), used in the post.
        /// </summary>
        protected abstract string RequestId { get; }

        /// <summary>
        /// The parameters for this request.
        /// </summary>
        protected abstract Dictionary<string, object> RequestParameters { get; }
    }
}
