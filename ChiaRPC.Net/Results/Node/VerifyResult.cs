using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class VerifyResult : ChiaResult
    {
        [JsonPropertyName("valid")] 
        public bool ValidSignature { get; init; }

        public VerifyResult()
        {
        }
    }
}
