using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class PoolStateResult : ChiaResult
    {
        [JsonPropertyName("has_value")]
        public bool HasValue { get; init; }

        [JsonPropertyName("pool_state")]
        public PoolState PoolState { get; init; }

        public PoolStateResult()
        {
        }
    }
}
