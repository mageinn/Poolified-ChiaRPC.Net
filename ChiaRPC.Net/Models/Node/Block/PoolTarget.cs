using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class PoolTarget
    {
        [JsonPropertyName("max_height")]
        public long MaxHeight { get; init; }

        [JsonPropertyName("puzzle_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PuzzleHash { get; init; }

        [JsonConstructor]
        public PoolTarget()
        {
        }
    }
}
