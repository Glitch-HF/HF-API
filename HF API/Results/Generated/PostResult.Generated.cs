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
    public partial class PostResult : APIResult
    {
        /// <summary>
        /// The post id.
        /// <summary>
        [JsonProperty("pid")]
        public long Id { get; set; }

        /// <summary>
        /// The thread id.
        /// <summary>
        [JsonProperty("tid")]
        public int ThreadId { get; set; }

        /// <summary>
        /// The user id of the author.
        /// <summary>
        [JsonProperty("uid")]
        public int UserId { get; set; }

        /// <summary>
        /// The forum id.
        /// <summary>
        [JsonProperty("fid")]
        public int ForumId { get; set; }

        /// <summary>
        /// The time that the thread was created.
        /// <summary>
        [JsonProperty("dateline"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// The message of the post.
        /// <summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The subject of the post.
        /// <summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The user id of the last editor.
        /// <summary>
        [JsonProperty("edituid")]
        public int EditUserId { get; set; }

        /// <summary>
        /// The time of the last edit.
        /// <summary>
        [JsonProperty("edittime"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime EditTime { get; set; }

        /// <summary>
        /// The reason behind the last edit.
        /// <summary>
        [JsonProperty("editreason")]
        public string EditReason { get; set; }

        /// <summary>
        /// The user that authored the post.
        /// <summary>
        [JsonProperty("author")]
        public UserResult User { get; set; }

        /// <summary>
        /// Gets the result parameter set from a new <see cref="PostRequest" /> instance.
        /// <summary>
        internal override Dictionary<string, object> GetResultParameters() => (Activator.CreateInstance<PostRequest>() as APIRequest).AddResultParameters();

    }
}

#endregion
