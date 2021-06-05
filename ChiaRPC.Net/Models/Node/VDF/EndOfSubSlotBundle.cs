using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class EndOfSubSlotBundle
    {
        [JsonPropertyName("challenge_chain")]
        public ChallengeChainSubSlot ChallengeChain { get; init; }

        public EndOfSubSlotBundle()
        {
        }
    }
}
