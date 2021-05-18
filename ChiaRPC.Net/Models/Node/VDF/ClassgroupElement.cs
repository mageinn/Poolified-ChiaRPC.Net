using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class ClassgroupElement
    {
        [JsonPropertyName("data")]
        public string Data { get; init; }

        public ClassgroupElement()
        {
        }
    }
}
