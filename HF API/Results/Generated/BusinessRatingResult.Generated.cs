//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HF_API.Results
{
    public partial class BusinessRatingResult : APIResult
    {
        /// <summary>
        /// The business rating id.
        /// <summary>
        [JsonProperty("crid")]
        public int Id { get; set; }

        /// <summary>
        /// The time the rating was given.
        /// <summary>
        [JsonProperty("dateline"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// The amount of the rating (+1, 0, -1).
        /// <summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// The message left with the rating.
        /// <summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The id of the contract this rating is linked to.
        /// <summary>
        [JsonProperty("contractid")]
        public int ContractId { get; set; }

        /// <summary>
        /// The contract that this rating is linked to.
        /// <summary>
        [JsonProperty("contract")]
        public ContractResult Contract { get; set; }

        /// <summary>
        /// The id of the user giving this rating.
        /// <summary>
        [JsonProperty("fromid")]
        public int FromUserId { get; set; }

        /// <summary>
        /// The user giving this rating.
        /// <summary>
        [JsonProperty("from")]
        public UserResult FromUser { get; set; }

        /// <summary>
        /// The id of the user receiving this rating.
        /// <summary>
        [JsonProperty("toid")]
        public int ToUserId { get; set; }

        /// <summary>
        /// The user receiving this rating.
        /// <summary>
        [JsonProperty("to")]
        public UserResult ToUser { get; set; }

        /// <summary>
        /// Gets the result parameter set from a new <see cref="BusinessRatingRequest" /> instance.
        /// <summary>
        internal override Dictionary<string, object> GetResultParameters() => (Activator.CreateInstance<BusinessRatingRequest>() as APIRequest).AddResultParameters();

    }
}

#endregion
