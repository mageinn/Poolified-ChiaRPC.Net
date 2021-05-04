﻿using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetPlotsResult : ChiaResult
    {
        [JsonPropertyName("failed_to_open_filenames")]
        public string[] FailedToOpenFileNames { get; init; }

        [JsonPropertyName("not_found_filenames")]
        public string[] NotFoundFilenames { get; init; }

        [JsonPropertyName("plots")]
        public Plot[] Plots { get; init; }

        [JsonConstructor]
        public GetPlotsResult()
        {
        }
    }
}
