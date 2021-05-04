using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    public class ChiaResult
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonConstructor]
        public ChiaResult()
        {
        }
    }
}
