using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class CoinRecordsResult : ChiaResult
    {
        [JsonPropertyName("coin_records")]
        public CoinRecord[] CoinRecords { get; init; }
    }
}
