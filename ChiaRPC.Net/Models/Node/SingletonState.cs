using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class SingletonState
    {
        [JsonPropertyName("buried_singleton_tip")]
        public CoinSolution BuriedSingletonSolution { get; init; }

        [JsonPropertyName("buried_singleton_tip_state")]
        public PoolState BuriedSingletonPoolState { get; init; }
        
        [JsonPropertyName("singleton_tip_state")]
        public PoolState SingletonPoolState { get; init; }

        public SingletonState()
        {
        }
    }
}
