using HF_API.Extensions;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HF_API.Converters
{
    /// <summary>
    /// Custom conversion of long time in seconds to TimeSpan.
    /// </summary>
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        /// <inheritdoc/>
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, [AllowNull] TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            TimeSpan.FromSeconds((reader.Value?.ToString() ?? "").TryParseLong());

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, [AllowNull] TimeSpan value, JsonSerializer serializer) => writer.WriteValue((long)value.TotalSeconds);
    }
}
