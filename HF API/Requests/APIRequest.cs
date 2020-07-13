using HF_API.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HF_API.Requests
{
    /// <summary>
    /// Represents an request to the HF API
    /// </summary>
    internal abstract class APIRequest
    {
        /// <summary>
        /// The base url.
        /// </summary>
        private const string URL_API_BASE = "https://hackforums.net/api/v2";

        /// <summary>
        /// The request posting parameters.
        /// </summary>
        /// <returns>The dictionary of parameters to pass into the request.</returns>
        protected abstract Dictionary<string, string> Parameters { get; }

        /// <summary>
        /// The request path (read/write/authorize).
        /// </summary>
        protected abstract string Path { get; }

        /// <summary>
        /// The success state of this request.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// The response message, if any.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets the path for this request endpoint.
        /// </summary>
        /// <returns>The url for the request.</returns>
        public string GetRequestPath() => UriHelper.Combine(URL_API_BASE, Path);

        /// <summary>
        /// Gets the content data for the request.
        /// </summary>
        /// <returns>The FormUrlEncodedContent to pass into the request.</returns>
        public FormUrlEncodedContent GetParameters() => new FormUrlEncodedContent(Parameters);

        /// <summary>
        /// Merges the deserialized request into the current object.
        /// </summary>
        /// <typeparam name="T">The type of request.</typeparam>
        /// <param name="result">The result APIRequest.</param>
        public void MergeResult<T>(T result) where T : APIRequest
        {
            if (typeof(T) != GetType() || result == null)
            {
                return;
            }

            // Iterate through the properties with the JsonProperty attribute and populate from the result.
            foreach (var prop in result.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(JsonPropertyAttribute))))
            {
                var value = prop.GetValue(result);
                prop.SetValue(this, value);
            }
        }
    }
}
