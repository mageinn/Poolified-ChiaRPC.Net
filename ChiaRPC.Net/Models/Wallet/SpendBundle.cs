using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class SpendBundle
    {
        [JsonPropertyName("coin_solutions")]
        public CoinSolution[] CoinSolutions { get; init; }

        [JsonPropertyName("aggregated_signature")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes AggregatedSignature { get; init; }
    }
}
