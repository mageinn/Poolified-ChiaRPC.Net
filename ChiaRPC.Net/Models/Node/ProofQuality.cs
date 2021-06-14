namespace ChiaRPC.Models
{
    public sealed class ProofQuality
    {
        public bool Valid { get; init; }
        public HexBytes QualityString { get; init; }

        internal ProofQuality(bool valid, HexBytes qualityString)
        {
            Valid = valid;
            QualityString = qualityString;
        }
    }
}
