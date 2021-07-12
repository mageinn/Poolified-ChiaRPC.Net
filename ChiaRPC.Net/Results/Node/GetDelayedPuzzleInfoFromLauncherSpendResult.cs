using ChiaRPC.Models;
using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal class GetDelayedPuzzleInfoFromLauncherSpendResult : ChiaResult
    {
        [JsonPropertyName("has_value")]
        public bool HasValue { get; init; }

        [JsonPropertyName("seconds")]
        public ulong Seconds { get; init; }

        [JsonPropertyName("delayed_puzzle_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes DelayedPuzzleHash { get; init; }

        public GetDelayedPuzzleInfoFromLauncherSpendResult()
        {
        }
    }
}
