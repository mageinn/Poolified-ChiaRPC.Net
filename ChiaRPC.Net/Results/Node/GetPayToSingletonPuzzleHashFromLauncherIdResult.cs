using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetPayToSingletonPuzzleHashFromLauncherIdResult : ChiaResult
    {
        [JsonPropertyName("p2_puzzle_hash")]
        public HexBytes PayToSingletonPuzzleHash { get; init; }

        public GetPayToSingletonPuzzleHashFromLauncherIdResult()
        {
        }
    }
}
