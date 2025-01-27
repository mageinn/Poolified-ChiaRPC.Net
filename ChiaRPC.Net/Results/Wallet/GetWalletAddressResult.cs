﻿using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    public sealed class GetWalletAddressResult : ChiaResult
    {
        [JsonPropertyName("wallet_id")]
        public int Id { get; init; }

        [JsonPropertyName("address")]
        public string Address { get; init; }

        public GetWalletAddressResult()
        {
        }
    }
}
