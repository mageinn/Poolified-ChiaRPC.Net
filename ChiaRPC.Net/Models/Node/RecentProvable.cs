using ChiaRPC.Parsers;
using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public abstract class RecentProvable
    {
        [JsonPropertyName("time_received")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset ReceivedAt { get; init; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; init; }

        protected RecentProvable(DateTimeOffset receivedAt, bool reverted)
        {
            ReceivedAt = receivedAt;
            Reverted = reverted;
        }
        protected RecentProvable()
        {
        }

        public abstract HexBytes GetChallengeHash();
    }
}
