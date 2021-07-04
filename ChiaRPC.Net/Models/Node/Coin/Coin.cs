using ChiaRPC.Parsers;
using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class Coin
    {
        [JsonPropertyName("parent_coin_info")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes ParentCoinInfo { get; init; }

        [JsonPropertyName("puzzle_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PuzzleHash { get; init; }

        [JsonPropertyName("amount")]
        public ulong Amount { get; init; }

        public Coin()
        {
        }

        public HexBytes Name()
            => (ParentCoinInfo + PuzzleHash + BitConverter.GetBytes(Amount)).Sha256();
    }
}
