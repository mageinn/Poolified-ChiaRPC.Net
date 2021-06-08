using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results.Node
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
