//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Converters;
using HF_API.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HF_API.Results
{
    public partial class UserResult : APIResult
    {
        /// <summary>
        /// The user's id.
        /// <summary>
        [JsonProperty("uid")]
        public int UserId { get; set; }

        /// <summary>
        /// The username.
        /// <summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The number of posts made.
        /// <summary>
        [JsonProperty("postnum")]
        public int PostCount { get; set; }

        /// <summary>
        /// The url or path to the user's avatar.
        /// <summary>
        [JsonProperty("avatar")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// The avatar dimensions.
        /// <summary>
        [JsonProperty("avatardimensions"), JsonConverter(typeof(AvatarSizeConverter))]
        public Size AvatarDimensions { get; set; }

        /// <summary>
        /// The avatar type.
        /// <summary>
        [JsonProperty("avatartype")]
        public string AvatarType { get; set; }

        /// <summary>
        /// The primary user group id.
        /// <summary>
        [JsonProperty("usergroup")]
        public int UserGroupId { get; set; }

        /// <summary>
        /// The display group id.
        /// <summary>
        [JsonProperty("displaygroup")]
        public int DisplayGroupId { get; set; }

        /// <summary>
        /// Comma-delimited list of secondary usergroups.
        /// <summary>
        [JsonProperty("additionalgroups"), JsonConverter(typeof(StringIntArrayConverter))]
        public int[] AdditionalGroupIds { get; set; }

        /// <summary>
        /// The number of awards received.
        /// <summary>
        [JsonProperty("awards")]
        public int Awards { get; set; }

        /// <summary>
        /// The number of threads created.
        /// <summary>
        [JsonProperty("threadnum")]
        public int ThreadCount { get; set; }

        /// <summary>
        /// The user title.
        /// <summary>
        [JsonProperty("usertitle")]
        public string UserTitle { get; set; }

        /// <summary>
        /// The user website.
        /// <summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// The accumulated time, in seconds, that the user has ever been online for.
        /// <summary>
        [JsonProperty("timeonline"), JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeOnline { get; set; }

        /// <summary>
        /// The total number of reputation points.
        /// <summary>
        [JsonProperty("reputation")]
        public int ReputationCount { get; set; }

        /// <summary>
        /// The total number of users referred.
        /// <summary>
        [JsonProperty("referrals")]
        public int ReferralsCount { get; set; }

        /// <summary>
        /// The total number of bytes currently held.
        /// <summary>
        [JsonProperty("myps")]
        public decimal BytesCount { get; set; }

        /// <summary>
        /// Gets the result parameter set from a new <see cref="UserRequest" /> instance.
        /// <summary>
        internal override Dictionary<string, object> GetResultParameters() => (Activator.CreateInstance<UserRequest>() as APIRequest).AddResultParameters();

    }
}

#endregion
