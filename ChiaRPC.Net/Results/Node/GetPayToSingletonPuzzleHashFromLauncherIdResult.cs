using ChiaRPC.Models;
using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetPayToSingletonPuzzleHashFromLauncherIdResult : ChiaResult
    {
        [JsonPropertyName("p2_puzzle_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PayToSingletonPuzzleHash { get; init; }

        public GetPayToSingletonPuzzleHashFromLauncherIdResult()
        {
        }
    }
}
