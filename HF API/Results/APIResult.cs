using HF_API.Converters;
using Newtonsoft.Json;

namespace HF_API.Results
{
    /// <summary>
    /// Represents a response from the HF API
    /// </summary>
    public abstract class APIResult
    {
        /// <summary>
        /// The success state of this request.
        /// </summary>
        [JsonProperty("success"), JsonConverter(typeof(BoolConverter))]
        public bool Success { get; set; } = true;

        /// <summary>
        /// The response message, if any.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Setup a parameterless constructor to enable deserialization on inherited classes.
        /// </summary>
        public APIResult() { }
    }
}
