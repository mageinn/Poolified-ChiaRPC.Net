namespace ChiaRPC.Models
{
    public sealed class DelayedPuzzleInfo
    {
        public ulong Seconds { get; init; }
        public HexBytes DelayedPuzzleHash { get; init; }

        public DelayedPuzzleInfo(ulong seconds, HexBytes delayedPuzzleHash)
        {
            Seconds = seconds;
            DelayedPuzzleHash = delayedPuzzleHash;
        }
    }
}
