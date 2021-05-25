using ChiaRPC.Parsers;
using ChiaRPC.Utils;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class ProofOfSpace
    {
        [JsonPropertyName("challenge")]
        public string Challenge { get; init; }

        [JsonPropertyName("plot_public_key")]
        [JsonConverter(typeof(G1ElementConverter))]
        public G1Element PlotPublicKey { get; init; }

        [JsonPropertyName("pool_public_key")]
        [JsonConverter(typeof(G1ElementConverter))]
        public G1Element PoolPublicKey { get; init; }

        [JsonPropertyName("pool_contract_puzzle_hash")]
        public string PoolContractPuzzleHash { get; init; }

        [JsonPropertyName("proof")]
        public string Proof { get; init; }

        [JsonPropertyName("size")]
        public ushort Size { get; init; }

        [JsonConstructor]
        public ProofOfSpace()
        {
        }

        public string GetPlotId()
        {
            if ((PoolPublicKey == null && string.IsNullOrWhiteSpace(PoolContractPuzzleHash)) ||
                (PoolPublicKey != null && !string.IsNullOrWhiteSpace(PoolContractPuzzleHash)))
            {
                return null;
            }

            return PoolPublicKey == null
                ? GetPlotIdByPuzzleHash()
                : GetPlotIdByPublicKey();
        }

        private string GetPlotIdByPuzzleHash()
        {
            byte[] bytes = HexUtils.HexStringToByteArray(PoolContractPuzzleHash + PlotPublicKey.ToString());
            byte[] hashedBytes = SHA256.HashData(bytes);
            return HexUtils.ByteArrayToHexString(hashedBytes);
        }
        private string GetPlotIdByPublicKey()
        {
            byte[] bytes = HexUtils.HexStringToByteArray(PoolPublicKey.ToString() + PlotPublicKey.ToString());
            byte[] hashedBytes = SHA256.HashData(bytes);
            return HexUtils.ByteArrayToHexString(hashedBytes);
        }
    }
}
