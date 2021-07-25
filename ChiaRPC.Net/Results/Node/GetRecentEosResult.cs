﻿using ChiaRPC.Models;
using ChiaRPC.Parsers;
using System;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetRecentEosResult : ChiaResult
    {
        [JsonPropertyName("eos")]
        public EndOfSubSlotBundle EndOfSubSlotBundle { get; init; }

        [JsonPropertyName("time_received")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset ReceivedAt { get; init; }

        [JsonPropertyName("peak_height")]
        public uint CurrentPeakHeight { get; init; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; init; }

        public GetRecentEosResult()
        {
        }
    }
}
