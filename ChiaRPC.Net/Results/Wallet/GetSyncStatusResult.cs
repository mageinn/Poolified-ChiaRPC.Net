using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal class GetSyncStatusResult : ChiaResult
    {
        [JsonPropertyName("synced")]
        public bool Synced { get; init; }

        [JsonPropertyName("syncing")]
        public bool Syncing { get; init; }

        [JsonPropertyName("genesis_initialized")]
        public bool GenesisInitialized { get; init; }

        public GetSyncStatusResult()
        {
        }
    }
}
