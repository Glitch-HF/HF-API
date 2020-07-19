using System;
using System.Collections.Generic;
using System.Text;

namespace HF_API.Requests
{
    /// <summary>
    /// Exception wrapper for api messages.
    /// </summary>
    public class APIException : Exception
    {
        /// <summary>
        /// The API Exception code.
        /// </summary>
        public APIExceptionCode Code { get; }

        /// <summary>
        /// Creates a new instance of the APIException.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="code">The exception code.</param>
        public APIException(string message, APIExceptionCode code) : base(message ?? string.Empty)
        {
            Code = code;
        }

        /// <summary>
        /// Creates a new exception from the given message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The exception code.></returns>
        public static APIException FromMessage(string message)
        {
            if (Enum.TryParse(message ?? string.Empty, out APIExceptionCode code))
            {
                return new APIException(GetMessage(code), code);
            }
            return new APIException(message, APIExceptionCode.UNKNOWN_RESPONSE);
        }

        /// <summary>
        /// Process the code into a friendly response.
        /// </summary>
        /// <param name="code">The exception code.</param>
        /// <returns>The description.</returns>
        private static string GetMessage(APIExceptionCode code) => code switch
        {
            APIExceptionCode.TOKEN_DISABLED => "The auth token has been disabled (user revoked access).",
            APIExceptionCode.TOKEN_EXPIRED => "The auth token has expired.",
            APIExceptionCode.INVALID_AUTH_CODE => "The authentication code specified during the authorize request was invalid.",
            _ => $"Unhandled exception code: {code.ToString()}"
        };
    }

    /// <summary>
    /// The response codes
    /// </summary>
    public enum APIExceptionCode
    {
        UNKNOWN_RESPONSE,
        TOKEN_DISABLED,
        TOKEN_EXPIRED,
        INVALID_AUTH_CODE
    }
}
