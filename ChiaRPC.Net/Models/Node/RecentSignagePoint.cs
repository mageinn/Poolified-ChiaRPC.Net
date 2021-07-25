using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class RecentSignagePoint : RecentProvable
    {
        [JsonPropertyName("signage_point")]
        public SignagePoint SignagePoint { get; init; }

        public RecentSignagePoint()
            : base()
        {
        }
        public RecentSignagePoint(SignagePoint signagePoint, DateTimeOffset receivedAt, uint currentPeakHeight, bool reverted)
            : base(receivedAt, currentPeakHeight, reverted)
        {
            SignagePoint = signagePoint;
        }

        public override HexBytes GetCCChallengeHash()
            => SignagePoint.CC_Vdf.Challenge;
        public override ulong GetCCNumberOfIterations()
            => SignagePoint.CC_Vdf.Iterations;
        public override HexBytes GetRCChallengeHash()
            => SignagePoint.RC_Vdf.Challenge;
    }
}
