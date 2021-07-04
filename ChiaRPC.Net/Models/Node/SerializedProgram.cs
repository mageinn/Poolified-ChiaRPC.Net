using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class SerializedProgram
    {
        [JsonPropertyName("_buf")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes Buffer { get; init; }

        public SerializedProgram()
        {
        }
    }
}
