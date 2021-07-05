using ChiaRPC.Parsers;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class ProofOfSpace
    {
        [JsonPropertyName("challenge")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes Challenge { get; init; }

        [JsonPropertyName("plot_public_key")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PlotPublicKey { get; init; }

        [JsonPropertyName("pool_public_key")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PoolPublicKey { get; init; }

        [JsonPropertyName("pool_contract_puzzle_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PoolContractPuzzleHash { get; init; }

        [JsonPropertyName("proof")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes Proof { get; init; }

        [JsonPropertyName("size")]
        public ushort Size { get; init; }

        [JsonConstructor]
        public ProofOfSpace()
        {
        }

        public HexBytes GetPlotId()
        {
            if (PoolPublicKey.IsEmpty == PoolContractPuzzleHash.IsEmpty)
            {
                return HexBytes.Empty;
            }
            //
            return PoolPublicKey.IsEmpty
                ? GetPlotIdByPuzzleHash()
                : GetPlotIdByPublicKey();
        }

        private HexBytes GetPlotIdByPuzzleHash()
        {
            var concatenated = PoolContractPuzzleHash + PlotPublicKey;
            return concatenated.Sha256();
        }
        private HexBytes GetPlotIdByPublicKey()
        {
            var concatenated = PoolPublicKey + PlotPublicKey;
            return concatenated.Sha256();
        }
    }
}
