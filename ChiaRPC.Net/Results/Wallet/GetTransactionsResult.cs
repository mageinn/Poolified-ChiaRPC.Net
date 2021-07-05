using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal class GetTransactionsResult : ChiaResult
    {
        [JsonPropertyName("transactions")]
        public TransactionRecord[] Transactions { get; init; }

        [JsonPropertyName("wallet_id")]
        public uint WalletId { get; init; }

        public GetTransactionsResult()
        {
        }
    }
}
