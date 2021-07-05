using ChiaRPC.Models;
using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal class TransactionResult : ChiaResult
    {
        [JsonPropertyName("transaction")]
        public TransactionRecord Transaction { get; init; }

        [JsonPropertyName("transaction_id")]
        public HexBytes TransactionId { get; init; }

        public TransactionResult()
        {
        }
    }
}
