using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HF_API.Requests.Auth
{
    internal class RequestAuth : APIRequest
    {
        /// <summary>
        /// The temporary authorization code.
        /// </summary>
        private string ClientId { get; }

        /// <summary>
        /// The temporary authorization code.
        /// </summary>
        private string ClientSecret { get; }

        /// <summary>
        /// The temporary authorization code.
        /// </summary>
        private string Code { get; }

        /// <summary>
        /// Returns the path for authorize requests.
        /// </summary>
        /// <returns>The path for authorize requests.</returns>
        protected override string Path => "authorize";

        /// <summary>
        /// The authorization parameters needed to post this request.
        /// </summary>
        /// <returns>The dictionary of parameters.</returns>
        protected override Dictionary<string, string> Parameters => new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "code", Code }
        };

        /// <summary>
        /// The token returned from this request.
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }

        /// <summary>
        /// The user id returned from this request.
        /// </summary>
        [JsonProperty("uid")]
        public int UserId { get; set; }

        /// <summary>
        /// Creates a new Authorization request from the callback code.
        /// </summary>
        /// <param name="code">The temporary authorization code.</param>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The secret key.</param>
        public RequestAuth(string clientId, string clientSecret, string code)
        {
            Code = code;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}
