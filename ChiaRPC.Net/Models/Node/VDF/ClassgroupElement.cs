using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class ClassgroupElement : IStreamable
    {
        [JsonPropertyName("data")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes Data { get; init; }

        public ClassgroupElement()
        {
        }

        public HexBytes Serialize()
            => Data;
    }
}
