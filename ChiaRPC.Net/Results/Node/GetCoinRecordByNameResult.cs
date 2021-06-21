using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetCoinRecordByNameResult : ChiaResult
    {
        [JsonPropertyName("coin_record")]
        public CoinRecord CoinRecord { get; init; }

        public GetCoinRecordByNameResult()
        {
        }
    }
}
