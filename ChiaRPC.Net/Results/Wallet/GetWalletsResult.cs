using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetWalletsResult : ChiaResult
    {
        [JsonPropertyName("wallets")]
        public WalletInfo[] Wallets { get; init; }

        public GetWalletsResult()
        {
        }
    }
}
