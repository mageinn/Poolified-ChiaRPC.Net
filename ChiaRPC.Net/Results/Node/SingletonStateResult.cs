using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal class SingletonStateResult : ChiaResult
    {
        [JsonPropertyName("has_value")]
        public bool HasValue { get; init; }

        [JsonPropertyName("singleton_state")]
        public SingletonState SingletonState { get; init; }

        public SingletonStateResult()
        {
        }
    }
}
