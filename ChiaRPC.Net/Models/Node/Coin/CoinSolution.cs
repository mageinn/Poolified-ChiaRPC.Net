using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class CoinSolution
    {
        [JsonPropertyName("coin")]
        public Coin Coin { get; init; }

        [JsonPropertyName("puzzle_reveal")]
        public SerializedProgram PuzzleReveal { get; init; }

        [JsonPropertyName("solution")]
        public SerializedProgram Solution { get; init; }

        public CoinSolution()
        {
        }
    }
}
