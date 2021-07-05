using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class Plot
    {
        [JsonPropertyName("file_size")]
        public ulong FileSize { get; set; }

        [JsonPropertyName("plot-seed")]
        public string Seed { get; set; }

        [JsonPropertyName("filename")]
        public string FileName { get; set; }

        [JsonPropertyName("plot_public_key")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PublicKey { get; set; }

        [JsonPropertyName("size")]
        public uint Size { get; set; }

        [JsonConstructor]
        public Plot()
        {
        }
    }
}
