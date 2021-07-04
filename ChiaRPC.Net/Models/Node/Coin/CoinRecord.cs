using ChiaRPC.Parsers;
using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class CoinRecord
    {
        [JsonPropertyName("coin")]
        public Coin Coin { get; init; }

        [JsonPropertyName("confirmed_block_index")]
        public uint ConfirmedBlockIndex { get; init; }

        [JsonPropertyName("spent_block_index")]
        public uint SpentBlockIndex { get; init; }

        [JsonPropertyName("spent")]
        public bool Spent { get; init; }

        [JsonPropertyName("coinbase")]
        public bool CoinBase { get; init; }

        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(JsonDateTimeOffsetConverter))]
        public DateTimeOffset Timestamp { get; init; }

        public HexBytes Name()
            => Coin.Name();

        public CoinRecord()
        {
        }
    }
}
