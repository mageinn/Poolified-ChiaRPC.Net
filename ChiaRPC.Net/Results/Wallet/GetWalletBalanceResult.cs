using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    public sealed class GetWalletBalanceResult : ChiaResult
    {
        [JsonPropertyName("wallet_balance")]
        public Wallet Wallet { get; init; }

        [JsonConstructor]
        public GetWalletBalanceResult()
        {
        }
    }
}
