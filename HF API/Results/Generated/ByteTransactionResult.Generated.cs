//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Converters;
using HF_API.Enums;
using HF_API.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HF_API.Results
{
    public partial class ByteTransactionResult : APIResult
    {
        /// <summary>
        /// The transaction id.
        /// <summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// <summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The time of the transaction.
        /// <summary>
        [JsonProperty("dateline"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// The type of transaction.
        /// <summary>
        [JsonProperty("type"), JsonConverter(typeof(ByteTransactionTypeConverter))]
        public ByteTransactionType Type { get; set; }

        /// <summary>
        /// The reason, if any, specified for the transaction.
        /// <summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// The user that initated the transaction.
        /// <summary>
        [JsonProperty("from")]
        public UserResult FromUser { get; set; }

        /// <summary>
        /// The recipient of the transaction.
        /// <summary>
        [JsonProperty("to")]
        public UserResult ToUser { get; set; }

        /// <summary>
        /// The post linked to this byte transaction (if any).
        /// <summary>
        [JsonProperty("post")]
        public PostResult Post { get; set; }

        /// <summary>
        /// Gets the result parameter set from a new <see cref="ByteTransactionRequest" /> instance.
        /// <summary>
        internal override Dictionary<string, object> GetResultParameters() => (Activator.CreateInstance<ByteTransactionRequest>() as APIRequest).AddResultParameters();

    }
}

#endregion
