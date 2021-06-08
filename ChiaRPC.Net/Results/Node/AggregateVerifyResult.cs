using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class AggregateVerifyResult : ChiaResult
    {
        [JsonPropertyName("valid_signature")] 
        public bool ValidSignature { get; init; }

        public AggregateVerifyResult()
        {
        }
    }
}
