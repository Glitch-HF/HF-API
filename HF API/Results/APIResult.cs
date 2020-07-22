using HF_API.Converters;
using HF_API.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// The response message, if any.
        /// </summary>
        [JsonProperty("message")]
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public APIExceptionCode ExceptionCode { get; set; }

        /// <summary>
        /// Setup a parameterless constructor to enable deserialization on inherited classes.
        /// </summary>
        public APIResult() { }

        /// <summary>
        /// Gets the result parameter dictionary.
        /// </summary>
        /// <returns></returns>
        internal virtual Dictionary<string, object> GetResultParameters() => throw new NotImplementedException($"{nameof(GetResultParameters)} is not implemented in subclass: {GetType().Name}");
    }
}
