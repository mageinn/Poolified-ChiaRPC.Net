using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class CoinSolution
    {
        [JsonPropertyName("name")]
        public Coin Coin { get; init; }

        [JsonPropertyName("puzzle_reveal")]
        public SerializedProgram Puzzle_Reveal { get; init; }

        [JsonPropertyName("solution")]
        public SerializedProgram Solution { get; init; }

        public CoinSolution()
        {
        }
    }
}
