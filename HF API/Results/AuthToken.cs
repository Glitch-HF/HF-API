using HF_API.Converters;
using HF_API.Enums;
using HF_API.Results;
using Newtonsoft.Json;
using System;

namespace HF_API
{
    /// <summary>
    /// Represents an authorization token to be used in API Requests.
    /// </summary>
    public class AuthToken : APIResult
    {
        /// <summary>
        /// The literal token string.
        /// </summary>
        [JsonProperty("access_token")]
        public string Token { get; set; }

        /// <summary>
        /// The user id.
        /// </summary>
        [JsonProperty("uid")]
        public int UserId { get; set; }

        /// <summary>
        /// The expiration date for this token.
        /// </summary>
        [JsonProperty("expiration_date")]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Set this property to update the <see cref="Expiration"/> property. This is only used on initial response deserialization.
        /// </summary>
        [JsonProperty("expires_in")]
        public long ExpiresIn
        {
            set
            {
                if (Expiration == null && value > 0)
                {
                    Expiration = DateTime.Now.AddSeconds(value);
                }
            }
        }

        /// <summary>
        /// The permissions available with this token.
        /// </summary>
        [JsonProperty("scope"), JsonConverter(typeof(APIPermissionsConverter))]
        public APIPermission[] Permissions { get; set; }
    }
}
