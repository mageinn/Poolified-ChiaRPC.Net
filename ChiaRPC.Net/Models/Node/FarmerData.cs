namespace ChiaRPC.Models
{
    public sealed class FarmerData
    {
        public CoinSolution LastSolution { get; init; }
        public PoolState SavedState { get; init; }
        public ulong DelayTime { get; init; }
        public HexBytes DelayPuzzleHash { get; init; }

        public FarmerData(CoinSolution lastSolution, PoolState savedState, ulong delayTime, HexBytes delayPuzzleHash)
        {
            LastSolution = lastSolution;
            SavedState = savedState;
            DelayTime = delayTime;
            DelayPuzzleHash = delayPuzzleHash;
        }
    }
}
