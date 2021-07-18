using ChiaRPC.Parsers;
using ChiaRPC.Utils;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class ProofOfSpace : IStreamable
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

        public bool TryGetPlotId(out HexBytes plotId)
            => TryGetPlotId(PoolPublicKey, PoolContractPuzzleHash, PlotPublicKey, out plotId);

        public static bool TryGetPlotId(HexBytes poolPublicKey, HexBytes poolContractPuzzleHash, HexBytes plotPublicKey, out HexBytes plotId)
        {
            if (poolPublicKey.IsEmpty == poolContractPuzzleHash.IsEmpty)
            {
                plotId = HexBytes.Empty;
                return false;
            }

            var concatenated = poolPublicKey + poolContractPuzzleHash + plotPublicKey;
            plotId = concatenated.Sha256();
            return true;
        }

        public HexBytes Serialize()
            => Challenge +
                StreamableUtils.WithOptional(PoolPublicKey) +
                StreamableUtils.WithOptional(PoolContractPuzzleHash) +
                PlotPublicKey +
                StreamableUtils.Serialize((byte)Size) +
                StreamableUtils.WithLength(Proof);
    }
}
