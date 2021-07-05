namespace ChiaRPC.Models
{
    public sealed class SyncStatus
    {
        public bool Synced { get; init; }
        public bool Syncing { get; init; }
        public bool GenesisInitialized { get; init; }

        public SyncStatus(bool synced, bool syncing, bool genesisInitialized)
        {
            Synced = synced;
            Syncing = syncing;
            GenesisInitialized = genesisInitialized;
        }
    }
}
