using HF_API.Enums;
using System.Collections.Generic;
using System.Net.Http;

namespace HF_API.Requests
{
    internal class AuthRequest : APIRequest
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
        /// This doesn't matter since we're overriding <see cref="GetParameters"/>
        /// </summary>
        protected override RequestAsk Ask => 0;

        /// <summary>
        /// The authorization parameters needed to post this request.
        /// </summary>
        /// <returns>The dictionary of parameters.</returns>
        protected override FormUrlEncodedContent GetParameters() => new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "client_id", ClientId },
            { "client_secret", ClientSecret },
            { "code", Code }
        });

        /// <summary>
        /// Whether this request requires an authorization token.
        /// </summary>
        protected override bool RequireAuthToken => false;

        /// <summary>
        /// Creates a new Authorization request from the callback code.
        /// </summary>
        /// <param name="code">The temporary authorization code.</param>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The secret key.</param>
        public AuthRequest(string clientId, string clientSecret, string code) : base()
        {
            Code = code;
            ClientId = clientId;
            ClientSecret = clientSecret;

            Type = RequestType.Authorize;
        }

        /// <summary>
        /// Gets the token from the specified client id, secret, and code.
        /// </summary>
        /// <param name="client">The HttpClient to use when getting the token.</param>
        /// <param name="clientId">The client_id for you HF API application.</param>
        /// <param name="clientSecret">The secret_key for your HF API application.</param>
        /// <param name="code">The code sent to the url specified on your HF API application when the user approves access for your app on HF.</param>
        /// <returns></returns>
        public static AuthToken GetToken(HttpClient client, string clientId, string clientSecret, string code) =>
            new AuthRequest(clientId, clientSecret, code).ProcessRequest<AuthToken>(client);
    }
}
