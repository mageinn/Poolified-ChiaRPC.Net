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
        public RecentSignagePoint(SignagePoint signagePoint, DateTimeOffset receivedAt, bool reverted)
            : base(receivedAt, reverted)
        {
            SignagePoint = signagePoint;
        }

        public override HexBytes GetChallengeHash()
            => SignagePoint.CC_Vdf.Challenge;
    }
}
