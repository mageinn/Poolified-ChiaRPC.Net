using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class Block
    {
        [JsonPropertyName("header_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes HeaderHash { get; init; }

        [JsonConstructor]
        public Block()
        {
        }
    }
}
