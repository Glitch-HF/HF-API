using HF_API.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace HF_API.Converters
{
    public class ByteTransactionTypeConverter : JsonConverter<ByteTransactionType>
    {
        /// <summary>
        /// Lookup for byte transaction types and conversions.
        /// </summary>
        private readonly Dictionary<string, ByteTransactionType> lookup = new Dictionary<string, ByteTransactionType>
        {
            { "bla", ByteTransactionType.BlackJack },
            { "slo", ByteTransactionType.Slots },
            { "don", ByteTransactionType.Donation },
            { "ltb", ByteTransactionType.Lotto },
            { "dci", ByteTransactionType.CheckIn },
            { "qlp", ByteTransactionType.QuickLove },
            { "cgp", ByteTransactionType.CryptoGame },
            { "sig", ByteTransactionType.Signature },
            { "hip", ByteTransactionType.Hackúman },
            { "sbw", ByteTransactionType.SportWager },
        };

        /// <inheritdoc />
        public override ByteTransactionType ReadJson(JsonReader reader, Type objectType, [AllowNull] ByteTransactionType existingValue, bool hasExistingValue, JsonSerializer serializer) =>
            lookup.TryGetValue(string.IsNullOrWhiteSpace(reader.Value?.ToString().Trim()) ? "unknown" : reader.Value?.ToString().Trim().ToLower(), out ByteTransactionType value) ? value : ByteTransactionType.Unknown;

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, [AllowNull] ByteTransactionType value, JsonSerializer serializer) =>
            writer.WriteValue(lookup.FirstOrDefault(kvp => kvp.Value == value).Key ?? "unknown");
    }
}
