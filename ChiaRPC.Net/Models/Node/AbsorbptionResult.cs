namespace ChiaRPC.Models
{
    public class AbsorbptionResult
    {
        public MempoolInclusionStatus Status { get; }
        public int Error { get; }

        public HexBytes CreatedCoinName { get; }
        public ulong FarmedHeight { get; }

        public AbsorbptionResult(MempoolInclusionStatus status, int error, 
            HexBytes createdCoinName, ulong farmedHeight)
        {
            Status = status;
            Error = error;
            CreatedCoinName = createdCoinName;
            FarmedHeight = farmedHeight;
        }
    }
}
