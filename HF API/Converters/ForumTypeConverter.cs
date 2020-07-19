using HF_API.Enums;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HF_API.Converters
{
    /// <summary>
    /// Converter for ForumType enums ('c' => Category, 'f' => Forum)
    /// </summary>
    public class ForumTypeConverter : JsonConverter<ForumType>
    {
        /// <inheritdoc />
        public override ForumType ReadJson(JsonReader reader, Type objectType, [AllowNull] ForumType existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            (reader.Value as string ?? "f").First() == 'c' ? ForumType.Category : ForumType.Forum;

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, [AllowNull] ForumType value, JsonSerializer serializer) =>
            writer.WriteValue(value.ToString().ToLower().First());
    }
}
