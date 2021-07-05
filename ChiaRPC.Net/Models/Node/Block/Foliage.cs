using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class Foliage
    {
        [JsonPropertyName("foliage_block_data_signature")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes BlockDataSignature { get; init; }
        [JsonPropertyName("foliage_block_data")]
        public BlockData BlockData { get; init; }
        [JsonPropertyName("reward_block_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes RewardBlockHash { get; init; }

        [JsonConstructor]
        public Foliage()
        {
        }
    }
}
