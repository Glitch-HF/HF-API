using HF_API.Requests;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HF_API
{
    /// <summary>
    /// Class for integrating with the HF API
    /// </summary>
    public partial class HFAPI
    {
        #region Constants

        /// <summary>
        /// The current version of the HF API.
        /// </summary>
        public const double ApiVersion = 2.0;

        #endregion

        #region Properties

        /// <summary>
        /// The HttpClient for this API Instance.
        /// </summary>
        public HttpClient Client { get; private set; }

        /// <summary>
        /// The client id.
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// The secret key.
        /// </summary>
        public string ClientSecret { get; private set; }

        /// <summary>
        /// The current authorization token.
        /// </summary>
        public AuthToken Token { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of the HFAPI from the given client id and secret key.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The secret key.</param>
        /// <param name="token">The auth token.</param>
        public HFAPI(string clientId, string clientSecret, AuthToken token = null)
        {
            Client = new HttpClient();
            ClientId = clientId;
            ClientSecret = clientSecret;

            SetAuthToken(token);
        }

        #endregion

        #region Authorize Requests

        /// <summary>
        /// Attempts to setup a token from the specified authorization code.
        /// </summary>
        /// <param name="code">The HF API code used to generate a token.</param>
        /// <param name="token">The acquired token.</param>
        public bool TryGetAuthToken(string code, out AuthToken token)
        {
            token = AuthRequest.GetToken(Client, ClientId, ClientSecret, code);
            return token.IsSuccess;
        }

        /// <summary>
        /// Sets the token on the current api client.
        /// </summary>
        /// <param name="token">The token.</param>
        public void SetAuthToken(AuthToken token)
        {
            if(token != null)
            {
                Token = token;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            }
        }

        #endregion
    }
}
