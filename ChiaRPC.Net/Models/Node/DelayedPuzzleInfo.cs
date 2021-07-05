namespace ChiaRPC.Models
{
    public sealed class DelayedPuzzleInfo
    {
        public ulong DelaySeconds { get; init; }
        public HexBytes DelayPuzzleHash { get; init; }

        public DelayedPuzzleInfo(ulong delaySeconds, HexBytes delayPuzzleHash)
        {
            DelaySeconds = delaySeconds;
            DelayPuzzleHash = delayPuzzleHash;
        }
    }
}
