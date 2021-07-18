﻿using ChiaRPC.Parsers;
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
        public ulong CurrentPeakHeight { get; init; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; init; }

        protected RecentProvable(DateTimeOffset receivedAt, ulong currentPeakHeight, bool reverted)
        {
            ReceivedAt = receivedAt;
            Reverted = reverted;
        }
        protected RecentProvable()
        {
        }

        public abstract HexBytes GetCCChallengeHash();
        public abstract HexBytes GetRCChallengeHash();
    }
}
