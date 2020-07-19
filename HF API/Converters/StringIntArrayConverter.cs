using HF_API.Extensions;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HF_API.Converters
{
    /// <summary>
    /// Custom conversion of comma-delimited strings to integer arrays.
    /// </summary>
    public class StringIntArrayConverter : JsonConverter<int[]>
    {
        /// <inheritdoc/>
        public override int[] ReadJson(JsonReader reader, Type objectType, [AllowNull] int[] existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            (reader.Value as string ?? "").SplitInts(',');

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, [AllowNull] int[] value, JsonSerializer serializer) => writer.WriteValue(value.JoinString(","));
    }
}
