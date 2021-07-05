using ChiaRPC.Models;
using ChiaRPC.Parsers;
using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    public sealed class GetRecentSignagePointResult : ChiaResult
    {
        [JsonPropertyName("signage_point")]
        public SignagePoint SignagePoint { get; init; }

        [JsonPropertyName("time_received")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset ReceivedAt { get; init; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; init; }

        public GetRecentSignagePointResult()
        {
        }
    }
}
