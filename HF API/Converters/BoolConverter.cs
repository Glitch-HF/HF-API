using HF_API.Extensions;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HF_API.Converters
{
    /// <summary>
    /// Custom conversion to boolean values because the default conversion implementation doesn't like 0-1s ??
    /// </summary>
    public class BoolConverter : JsonConverter<bool>
    {
        /// <inheritdoc />
        public override bool ReadJson(JsonReader reader, Type objectType, [AllowNull] bool existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            reader.Value.TryParseBoolean(existingValue);

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, [AllowNull] bool value, JsonSerializer serializer) => writer.WriteValue((value ? 1 : 0).ToString());
    }
}
