//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace HF_API.Results
{
    public partial class ThreadResult : APIResult
    {
        /// <summary>
        /// The thread id.
        /// <summary>
        [JsonProperty("tid")]
        public int Id { get; set; }

        /// <summary>
        /// The forum id.
        /// <summary>
        [JsonProperty("fid")]
        public int ForumId { get; set; }

        /// <summary>
        /// The thread subject.
        /// <summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The thread prefix id.
        /// <summary>
        [JsonProperty("prefix")]
        public int PrefixId { get; set; }

        /// <summary>
        /// The icon id.
        /// <summary>
        [JsonProperty("icon")]
        public int IconId { get; set; }

        /// <summary>
        /// The poll id.
        /// <summary>
        [JsonProperty("poll")]
        public int PollId { get; set; }

        /// <summary>
        /// The user id of the author.
        /// <summary>
        [JsonProperty("uid")]
        public int UserId { get; set; }

        /// <summary>
        /// The username of the thread author.
        /// <summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The time that the thread was created.
        /// <summary>
        [JsonProperty("dateline"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// The id of the first post.
        /// <summary>
        [JsonProperty("firstpost")]
        public long FirstPostId { get; set; }

        /// <summary>
        /// The time of the last post.
        /// <summary>
        [JsonProperty("lastpost"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastPostTime { get; set; }

        /// <summary>
        /// The name of the user that made the last post.
        /// <summary>
        [JsonProperty("lastposter")]
        public string LastPostUsername { get; set; }

        /// <summary>
        /// The id of the last poster.
        /// <summary>
        [JsonProperty("lastposteruid")]
        public int LastPostUid { get; set; }

        /// <summary>
        /// The total number of views.
        /// <summary>
        [JsonProperty("views")]
        public int ViewCount { get; set; }

        /// <summary>
        /// The total number of replies.
        /// <summary>
        [JsonProperty("numreplies")]
        public int ReplyCount { get; set; }

        /// <summary>
        /// Whether the thread is closed or not.
        /// <summary>
        [JsonProperty("closed"), JsonConverter(typeof(BoolConverter))]
        public bool IsClosed { get; set; }

        /// <summary>
        /// Whether the thread is sticky or not.
        /// <summary>
        [JsonProperty("sticky"), JsonConverter(typeof(BoolConverter))]
        public bool IsSticky { get; set; }

        /// <summary>
        /// The id of the highest rated post.
        /// <summary>
        [JsonProperty("bestpid")]
        public int BestPostId { get; set; }

    }
}

#endregion
