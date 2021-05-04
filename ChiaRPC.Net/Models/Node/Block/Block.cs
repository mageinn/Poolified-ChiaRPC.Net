using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class Block
    {
        [JsonPropertyName("header_hash")]
        public string HeaderHash { get; init; }

        [JsonConstructor]
        public Block()
        {
        }
    }
}
