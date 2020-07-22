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
    public partial class ContractResult : APIResult
    {
        /// <summary>
        /// The contract id.
        /// <summary>
        [JsonProperty("cid")]
        public int Id { get; set; }

        /// <summary>
        /// The time that the contract was initiated.
        /// <summary>
        [JsonProperty("dateline"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime InitTime { get; set; }

        /// <summary>
        /// The time that the contract was accepted by the other user.
        /// <summary>
        [JsonProperty("otherdateline"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime AcceptTime { get; set; }

        /// <summary>
        /// True if the contract is public, false if private.
        /// <summary>
        [JsonProperty("public"), JsonConverter(typeof(BoolConverter))]
        public bool IsPublic { get; set; }

        /// <summary>
        /// The number of days until the contract expires.
        /// <summary>
        [JsonProperty("timeout_days")]
        public int TimeoutDays { get; set; }

        /// <summary>
        /// The date that the contract is set to expire.
        /// <summary>
        [JsonProperty("timeout"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// The contract terms.
        /// <summary>
        [JsonProperty("terms")]
        public string Terms { get; set; }

        /// <summary>
        /// The id of the thread the contract is linked to.
        /// <summary>
        [JsonProperty("tid")]
        public int ThreadId { get; set; }

        /// <summary>
        /// The thread the contract is linked to.
        /// <summary>
        [JsonProperty("thread")]
        public ThreadResult Thread { get; set; }

        /// <summary>
        /// The id of the template used to create the contract.
        /// <summary>
        [JsonProperty("template_id")]
        public int TemplateId { get; set; }

        /// <summary>
        /// True if the contract was canceled.
        /// <summary>
        [JsonProperty("cancelstatus"), JsonConverter(typeof(BoolConverter))]
        public bool IsCanceled { get; set; }

        /// <summary>
        /// The type of contract (from the initiator side).
        /// <summary>
        [JsonProperty("type")]
        public ContractPosition Position { get; set; }

        /// <summary>
        /// The id of the user that initiated the contract.
        /// <summary>
        [JsonProperty("inituid")]
        public int InitUserId { get; set; }

        /// <summary>
        /// The user that initiated the contract.
        /// <summary>
        [JsonProperty("inituser")]
        public UserResult InitUser { get; set; }

        /// <summary>
        /// The id of the user that received the contract.
        /// <summary>
        [JsonProperty("otheruid")]
        public int OtherUserId { get; set; }

        /// <summary>
        /// The user that received the contract.
        /// <summary>
        [JsonProperty("otheruser")]
        public UserResult OtherUser { get; set; }

        /// <summary>
        /// The id of the middleman.
        /// <summary>
        [JsonProperty("muid")]
        public int MiddleManUserId { get; set; }

        /// <summary>
        /// The middleman user.
        /// <summary>
        [JsonProperty("escrow")]
        public UserResult MiddleManUser { get; set; }

        /// <summary>
        /// The price that the initiating user will pay.
        /// <summary>
        [JsonProperty("iprice")]
        public string InitPrice { get; set; }

        /// <summary>
        /// The price that the other user will pay.
        /// <summary>
        [JsonProperty("oprice")]
        public string OtherPrice { get; set; }

        /// <summary>
        /// The price currency for the user that initiated the contract.
        /// <summary>
        [JsonProperty("icurrency")]
        public string InitPriceCurrency { get; set; }

        /// <summary>
        /// The price currency for the user that received the contract.
        /// <summary>
        [JsonProperty("ocurrency")]
        public string OtherPriceCurrency { get; set; }

        /// <summary>
        /// The payment address for the user that initiated the contract.
        /// <summary>
        [JsonProperty("iaddress")]
        public string InitPaymentAddress { get; set; }

        /// <summary>
        /// The payment address for the user that received the contract.
        /// <summary>
        [JsonProperty("oaddress")]
        public string OtherPaymentAddress { get; set; }

        /// <summary>
        /// The product or service being provided from the user that initiated the contract.
        /// <summary>
        [JsonProperty("iproduct")]
        public string InitProduct { get; set; }

        /// <summary>
        /// The product or service being provided from the user that received the contract.
        /// <summary>
        [JsonProperty("oproduct")]
        public string OtherProduct { get; set; }

        /// <summary>
        /// The linked dispute left by the user that initiated the contract.
        /// <summary>
        [JsonProperty("idispute")]
        public DisputeResult InitDispute { get; set; }

        /// <summary>
        /// The linked dispute left by the user that received the contract.
        /// <summary>
        [JsonProperty("odispute")]
        public DisputeResult OtherDispute { get; set; }

        /// <summary>
        /// The business rating left by the user that initiated the contract.
        /// <summary>
        [JsonProperty("ibrating")]
        public BusinessRatingResult InitRating { get; set; }

        /// <summary>
        /// The business rating left by the user that received the contract.
        /// <summary>
        [JsonProperty("obrating")]
        public BusinessRatingResult OtherRating { get; set; }

        /// <summary>
        /// Field 'status', need more information to implement.
        /// <summary>
        [JsonProperty("status")]
        public object Status { get; set; }

        /// <summary>
        /// Field 'status', need more information to implement.
        /// <summary>
        [JsonProperty("istatus")]
        public object InitStatus { get; set; }

        /// <summary>
        /// Field 'status', need more information to implement.
        /// <summary>
        [JsonProperty("ostatus")]
        public object OtherStatus { get; set; }

        /// <summary>
        /// Gets the result parameter set from a new <see cref="ContractRequest" /> instance.
        /// <summary>
        internal override Dictionary<string, object> GetResultParameters() => (Activator.CreateInstance<ContractRequest>() as APIRequest).AddResultParameters();

    }
}

#endregion
