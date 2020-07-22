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
    public partial class DisputeResult : APIResult
    {
        /// <summary>
        /// The dispute id.
        /// <summary>
        [JsonProperty("cdid")]
        public int Id { get; set; }

        /// <summary>
        /// The time the dispute was opened.
        /// <summary>
        [JsonProperty("dateline"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Time { get; set; }

        /// <summary>
        /// The id of the thread linked to this dispute.
        /// <summary>
        [JsonProperty("dispute_tid")]
        public int DisputeThreadId { get; set; }

        /// <summary>
        /// The thread linked to this dispute.
        /// <summary>
        [JsonProperty("dispute_thread")]
        public ThreadResult DisputeThread { get; set; }

        /// <summary>
        /// The contract id.
        /// <summary>
        [JsonProperty("contractid")]
        public int ContractId { get; set; }

        /// <summary>
        /// The contract associated with this dispute.
        /// <summary>
        [JsonProperty("contract")]
        public ContractResult Contract { get; set; }

        /// <summary>
        /// The id of the user that initiated the dispute.
        /// <summary>
        [JsonProperty("claimantuid")]
        public int ClaimantUserId { get; set; }

        /// <summary>
        /// The user that initiated the dispute.
        /// <summary>
        [JsonProperty("claimant")]
        public UserResult ClaimantUser { get; set; }

        /// <summary>
        /// The information provided by the user that initiated the dispute.
        /// <summary>
        [JsonProperty("claimantnotes")]
        public string ClaimantNotes { get; set; }

        /// <summary>
        /// The id of the user that is receiving the dispute.
        /// <summary>
        [JsonProperty("defendantuid")]
        public int DefendantUserId { get; set; }

        /// <summary>
        /// The user that is receiving the dispute.
        /// <summary>
        [JsonProperty("defendant")]
        public UserResult DefendantUser { get; set; }

        /// <summary>
        /// The information provided by the user that is receiving the dispute.
        /// <summary>
        [JsonProperty("defendantnotes")]
        public string DefendantNotes { get; set; }

        /// <summary>
        /// Field 'status', need more information to implement.
        /// <summary>
        [JsonProperty("status")]
        public object Status { get; set; }

        /// <summary>
        /// Gets the result parameter set from a new <see cref="DisputeRequest" /> instance.
        /// <summary>
        internal override Dictionary<string, object> GetResultParameters() => (Activator.CreateInstance<DisputeRequest>() as APIRequest).AddResultParameters();

    }
}

#endregion
