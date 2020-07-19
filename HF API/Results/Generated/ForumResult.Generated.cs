//////////////////////////////////////////////
/// This class is automatically generated. ///
/// Do not attempt to modify as it will be ///
/// overwritten on the next build attempt. ///
//////////////////////////////////////////////

#region Auto-Generated Code

using HF_API.Converters;
using HF_API.Enums;
using Newtonsoft.Json;

namespace HF_API.Results
{
    public partial class ForumResult : APIResult
    {
        /// <summary>
        /// The forum id.
        /// <summary>
        [JsonProperty("fid")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the forum.
        /// <summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the forum.
        /// <summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The forum type (category or forum).
        /// <summary>
        [JsonProperty("type"), JsonConverter(typeof(ForumTypeConverter))]
        public ForumType Type { get; set; }

    }
}

#endregion
