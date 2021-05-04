using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetConnectionsResult : ChiaResult
    {
        [JsonPropertyName("connections")]
        public ChiaConnection[] Connections { get; init; }


        [JsonConstructor]
        public GetConnectionsResult()
        {
        }
    }
}
