using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class PoolTarget
    {
        [JsonPropertyName("max_height")]
        public long MaxHeight { get; init; }

        [JsonPropertyName("puzzle_hash")]
        public string PuzzleHash { get; init; }

        [JsonConstructor]
        public PoolTarget()
        {
        }
    }
}
