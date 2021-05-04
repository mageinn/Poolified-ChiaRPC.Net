using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetBlockchainStateResult : ChiaResult
    {
        [JsonPropertyName("blockchain_state")]
        public BlockchainState BlockchainState { get; init; }

        [JsonConstructor]
        public GetBlockchainStateResult()
        {
        }
    }
}
