using HF_API.Helpers;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace HF_API.Converters
{
    /// <summary>
    /// Custom converter of avatar dimension strings and Size structs.
    /// </summary>
    public class AvatarSizeConverter : JsonConverter<Size>
    {
        /// <inheritdoc/>
        public override Size ReadJson(JsonReader reader, Type objectType, [AllowNull] Size existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            ConversionHelper.ParseSize((reader.Value as string ?? ""), '|');

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, [AllowNull] Size value, JsonSerializer serializer) => writer.WriteValue($"{value.Width}|{value.Height}");
    }
}
