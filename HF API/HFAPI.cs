using HF_API.Requests;
using HF_API.Requests.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HF_API
{
    /// <summary>
    /// Class for integrating with the HF API
    /// </summary>
    public class HFAPI
    {
        /// <summary>
        /// The current version of the HF API.
        /// </summary>
        public const double API_VERSION = 2.0;

        /// <summary>
        /// The HttpClient for this API Instance.
        /// </summary>
        private HttpClient Client { get; }

        /// <summary>
        /// The client id.
        /// </summary>
        private string ClientId { get; }

        /// <summary>
        /// The secret key.
        /// </summary>
        private string ClientSecret { get; }

        /// <summary>
        /// The current authorization token.
        /// </summary>
        private string Token { get; set; }

        /// <summary>
        /// The current user id.
        /// </summary>
        private int UserId { get; set; }

        /// <summary>
        /// Create a new instance of the HFAPI from the given client id and secret key.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The secret key.</param>
        /// <param name="token">The token (optional -- must call authorize from a code if not initially defined).</param>
        /// <param name="userId">The user id (optional -- must call authorize from a code if not initially defined).</param>
        public HFAPI(string clientId, string clientSecret, string token = null, int userId = 0)
        {
            Client = new HttpClient();
            ClientId = clientId;
            ClientSecret = clientSecret;
            Token = token;
            UserId = userId;

            if (Token != null)
            {
                SetAuthToken(Token);
            }
        }

        /// <summary>
        /// Attempts to process the request.
        /// </summary>
        /// <param name="request">The APIRequest to process.</param>
        /// <param name="isAuthRequest">True if this is an authorize request (skip token validation), otherwise false.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        private bool ProcessRequest<T>(T request, bool isAuthRequest = false) where T : APIRequest
        {
            var requestTask = ProcessRequestAsync(request, isAuthRequest);
            requestTask.Wait();

            Console.WriteLine(UserId);

            return requestTask.Result;
        }

        /// <summary>
        /// Attempts to process the request.
        /// </summary>
        /// <param name="request">The APIRequest to process.</param>
        /// <param name="isAuthRequest">True if this is an authorize request (skip token validation), otherwise false.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        private async Task<bool> ProcessRequestAsync<T>(T request, bool isAuthRequest = false) where T : APIRequest
        {
            try
            {
                if (Token == null && !isAuthRequest)
                {
                    throw new Exception("Read/Write requests can't be made until the auth token has been defined.");
                }

                var response = await Client.PostAsync(request.GetRequestPath(), request.GetParameters());
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(json);
                    request.MergeResult(result);
                    return true;
                }
                else
                {
                    throw new Exception($"Unsuccessful response code from server: {response.StatusCode.ToString()} ({(int)response.StatusCode})");
                }
            }
            catch (Exception ex)
            {
                request.Message = ex.ToString();
            }
            return false;
        }

        #region Authorize

        /// <summary>
        /// Gets the authenti
        /// </summary>
        /// <param name="code"></param>
        public void Authorize(string code)
        {
            var request = new RequestAuth(ClientId, ClientSecret, code);
            if (ProcessRequest(request, true))
            {
                Token = request.Token;
                UserId = request.UserId;
                SetAuthToken(Token);
            }
            else
            {
                throw new Exception(request.Message ?? "Failed to send authorization request");
            }
        }

        /// <summary>
        /// Sets the token on the current api client.
        /// </summary>
        /// <param name="token">The token.</param>
        public void SetAuthToken(string token)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        #endregion

        #region Read



        #endregion

        #region Write



        #endregion
    }
}
