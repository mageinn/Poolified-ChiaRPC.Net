using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetPuzzleAndSolutionResult : ChiaResult
    {
        [JsonPropertyName("coin_solution")]
        public CoinSolution CoinSolution { get; init; }

        public GetPuzzleAndSolutionResult()
        {
        }
    }
}
