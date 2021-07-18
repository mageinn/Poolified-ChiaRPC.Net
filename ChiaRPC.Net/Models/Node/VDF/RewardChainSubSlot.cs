using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class RewardChainSubSlot
    {
        [JsonPropertyName("end_of_slot_vdf")]
        public VdfInfo EndOfSlotVDF { get; init; }

        [JsonPropertyName("challenge_chain_sub_slot_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes ChallengeChainSubSlotHash { get; init; }

        [JsonPropertyName("infused_challenge_chain_sub_slot_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes InfusedChallengeChainSubSlotHash { get; init; }

        [JsonPropertyName("deficit")]
        public byte Deficit { get; init; }

        public RewardChainSubSlot()
        {
        }
    }
}
