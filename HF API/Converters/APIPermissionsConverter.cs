using HF_API.Enums;
using HF_API.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HF_API.Converters
{
    /// <summary>
    /// Handles conversion between a space-delimited string and an APIPermission array.
    /// </summary>
    public class APIPermissionsConverter : JsonConverter<APIPermission[]>
    {
        /// <inheritdoc/>
        public override APIPermission[] ReadJson(JsonReader reader, Type objectType, [AllowNull] APIPermission[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = new List<APIPermission>();
            foreach (var token in (reader.Value as string ?? "").Split(' '))
            {
                if (Enum.TryParse(token, out APIPermission perm))
                {
                    result.Add(perm);
                }
                // All write tokens end in WRITE and have a read counterpart (same name without the 'write').
                // If the token has write access, then they are given read by default, so add it here.
                if (token.EndsWith("WRITE") && Enum.TryParse(token[0..^"WRITE".Length], out APIPermission readPerm))
                {
                    result.Add(readPerm);
                }
            }
            return result.Distinct().ToArray();
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, [AllowNull] APIPermission[] value, JsonSerializer serializer) =>
            writer.WriteValue(value.Select(perm => perm.ToString()).JoinString(" "));
    }
}
