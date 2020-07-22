//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Converters;
using HF_API.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HF_API.Results
{
    public partial class AdvancedProfileResult : ProfileResult
    {
        /// <summary>
        /// The unix time stamp of the last time the user was active.
        /// <summary>
        [JsonProperty("lastactive"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastActive { get; set; }

        /// <summary>
        /// The total count of unread pms.
        /// <summary>
        [JsonProperty("unreadpms")]
        public int UnreadPMCount { get; set; }

        /// <summary>
        /// True if the user has turned on invisible status.
        /// <summary>
        [JsonProperty("invisible"), JsonConverter(typeof(BoolConverter))]
        public bool IsInvisible { get; set; }

        /// <summary>
        /// The total number of PMs this user has made.
        /// <summary>
        [JsonProperty("totalpms")]
        public int TotalPMCount { get; set; }

        /// <summary>
        /// The total number of warning points on this user.
        /// <summary>
        [JsonProperty("warningpoints")]
        public decimal WarningPointsCount { get; set; }

        /// <summary>
        /// Gets the result parameter set from a new <see cref="AdvancedProfileRequest" /> instance.
        /// <summary>
        internal override Dictionary<string, object> GetResultParameters() => (Activator.CreateInstance<AdvancedProfileRequest>() as APIRequest).AddResultParameters();

    }
}

#endregion
