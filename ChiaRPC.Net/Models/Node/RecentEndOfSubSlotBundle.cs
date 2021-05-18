using ChiaRPC.Parsers;
using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class RecentEndOfSubSlotBundle
    {
        [JsonPropertyName("eos")]
        public EndOfSubSlotBundle EndOfSubSlotBundle { get; init; }

        [JsonPropertyName("time_received")]
        [JsonConverter(typeof(JsonDateTimeOffsetConverter))]
        public DateTimeOffset ReceivedAt { get; init; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; init; }

        public RecentEndOfSubSlotBundle()
        {
        }
        public RecentEndOfSubSlotBundle(EndOfSubSlotBundle endOfSubSlotBundle, DateTimeOffset receivedAt, bool reverted)
        {
            EndOfSubSlotBundle = endOfSubSlotBundle;
            ReceivedAt = receivedAt;
            Reverted = reverted;
        }
    }
}
