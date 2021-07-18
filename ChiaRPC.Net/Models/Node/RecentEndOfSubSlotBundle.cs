using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class RecentEndOfSubSlotBundle : RecentProvable
    {
        [JsonPropertyName("eos")]
        public EndOfSubSlotBundle EndOfSubSlotBundle { get; init; }

        public RecentEndOfSubSlotBundle()
            : base()
        {
        }

        public RecentEndOfSubSlotBundle(EndOfSubSlotBundle endOfSubSlotBundle, DateTimeOffset receivedAt, ulong currentPeakHeight, bool reverted)
            : base(receivedAt, currentPeakHeight, reverted)
        {
            EndOfSubSlotBundle = endOfSubSlotBundle;
        }

        public override HexBytes GetCCChallengeHash()
            => EndOfSubSlotBundle.ChallengeChain.ChallengeChainEndOfSlotVdf.Challenge;
        public override ulong GetCCNumberOfIterations()
            => EndOfSubSlotBundle.ChallengeChain.ChallengeChainEndOfSlotVdf.Iterations;
        public override HexBytes GetRCChallengeHash()
            => EndOfSubSlotBundle.RewardChain.EndOfSlotVDF.Challenge;
    }
}
