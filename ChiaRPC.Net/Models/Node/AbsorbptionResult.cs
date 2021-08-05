namespace ChiaRPC.Models
{
    public class AbsorbptionResult
    {
        public MempoolInclusionStatus Status { get; }
        public int Error { get; }
        public HexBytes CreatedCoinName { get; }

        public AbsorbptionResult(MempoolInclusionStatus status, int error, HexBytes createdCoinName)
        {
            Status = status;
            Error = error;
            CreatedCoinName = createdCoinName;
        }
    }
}
