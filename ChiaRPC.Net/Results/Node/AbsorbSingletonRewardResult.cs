﻿using ChiaRPC.Models;
using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class AbsorbSingletonRewardResult : ChiaResult
    {
        [JsonPropertyName("status")]
        public MempoolInclusionStatus Status { get; init; }

        [JsonPropertyName("error")]
        public int Error { get; init; }

        [JsonPropertyName("created_coin_name")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes? CreatedCoinName { get; init; }

        [JsonPropertyName("farmed_height")]
        public ulong? FarmedHeight { get; init; }

        public AbsorbSingletonRewardResult()
        {
        }
    }
}
