using ChiaRPC.Parsers;
using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class RecentSignagePoint
    {
        [JsonPropertyName("signage_point")]
        public SignagePoint SignagePoint { get; init; }

        [JsonPropertyName("time_received")]
        [JsonConverter(typeof(JsonDateTimeOffsetConverter))]
        public DateTimeOffset ReceivedAt { get; init; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; init; }

        public RecentSignagePoint()
        {
        }
        public RecentSignagePoint(SignagePoint signagePoint, DateTimeOffset receivedAt, bool reverted)
        {
            SignagePoint = signagePoint;
            ReceivedAt = receivedAt;
            Reverted = reverted;
        }
    }
}
