using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class AbsorbSingletonRewardResult : ChiaResult
    {
        [JsonPropertyName("status")]
        public MempoolInclusionStatus Status { get; init; }

        [JsonPropertyName("error")]
        public int Error { get; init; }

        [JsonPropertyName("created_coin_name")]
        public HexBytes CreatedCoinName { get; init; }

        public AbsorbSingletonRewardResult()
        {
        }
    }
}
