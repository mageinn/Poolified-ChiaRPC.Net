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

        [JsonPropertyName("peak_height")]
        public uint CurrentPeakHeight { get; init; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; init; }

        protected RecentProvable(DateTimeOffset receivedAt, uint currentPeakHeight, bool reverted)
        {
            ReceivedAt = receivedAt;
            CurrentPeakHeight = currentPeakHeight;
            Reverted = reverted;
        }
        protected RecentProvable()
        {
        }

        public abstract HexBytes GetCCChallengeHash();
        public abstract ulong GetCCNumberOfIterations();
        public abstract HexBytes GetRCChallengeHash();
    }
}
