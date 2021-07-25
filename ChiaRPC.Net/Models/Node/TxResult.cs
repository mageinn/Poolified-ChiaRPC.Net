namespace ChiaRPC.Models
{
    public class TxResult
    {
        public MempoolInclusionStatus Status { get; }
        public int Error { get; }

        public TxResult(MempoolInclusionStatus status, int error)
        {
            Status = status;
            Error = error;
        }
    }
}
