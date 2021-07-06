using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class PoolState
    {
        [JsonPropertyName("version")]
        public byte Version { get; init; }

        [JsonPropertyName("state")]
        public PoolSingletonState State { get; init; }

        [JsonPropertyName("target_puzzle_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes TargetPuzzleHash { get; init; }

        [JsonPropertyName("owner_pubkey")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes OwnerPublicKey { get; init; }

        [JsonPropertyName("pool_url")]
        public string PoolUrl { get; init; }

        [JsonPropertyName("relative_lock_height")]
        public uint RelativeLockHeight { get; init; }

        public PoolState()
        {
        }
    }
}
