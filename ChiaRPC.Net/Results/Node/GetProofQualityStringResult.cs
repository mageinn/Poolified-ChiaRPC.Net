using ChiaRPC.Models;
using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetProofQualityStringResult : ChiaResult
    {
        [JsonPropertyName("valid")]
        public bool Valid { get; init; }

        [JsonPropertyName("quality_str")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes QualityString { get; init; }

        public GetProofQualityStringResult()
        {
        }
    }
}
