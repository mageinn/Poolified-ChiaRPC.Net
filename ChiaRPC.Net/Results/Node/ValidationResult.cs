using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class ValidationResult : ChiaResult
    {
        [JsonPropertyName("valid")] 
        public bool Valid { get; init; }

        public ValidationResult()
        {
        }
    }
}
