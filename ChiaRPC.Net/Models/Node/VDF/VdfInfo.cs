﻿using ChiaRPC.Parsers;
using ChiaRPC.Utils;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class VdfInfo : IStreamable
    {
        [JsonPropertyName("challenge")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes Challenge { get; init; }

        [JsonPropertyName("number_of_iterations")]
        public ulong Iterations { get; init; }

        [JsonPropertyName("output")]
        public ClassgroupElement Output { get; init; }

        public VdfInfo()
        {
        }

        public HexBytes Serialize()
            => Challenge +
                StreamableUtils.Serialize(Iterations) +
                Output.Serialize();
    }
}
