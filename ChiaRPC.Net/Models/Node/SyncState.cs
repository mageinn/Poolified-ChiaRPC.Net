using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class SyncState
    {
        [JsonPropertyName("sync_mode")]
        public bool Mode { get; init; }

        [JsonPropertyName("sync_progress_height")]
        public ulong ProgressHeight { get; init; }

        [JsonPropertyName("sync_tip_height")]
        public ulong TipHeight { get; init; }

        [JsonPropertyName("synced")]
        public bool Synced { get; init; }

        [JsonConstructor]
        public SyncState()
        {
        }
    }
}
