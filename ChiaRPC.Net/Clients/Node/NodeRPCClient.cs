using ChiaRPC.Models;
using ChiaRPC.Results;
using ChiaRPC.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public sealed class NodeRPCClient : ChiaRPCClient, IExtendedNodeRPCClient
    {
        public NodeRPCClient(ChiaRPCOptions options, string apiUrl) 
            : base(options, "full_node", apiUrl)
        {
        }

        public async Task<BlockchainState> GetBlockchainStateAsync()
        {
            var result = await PostAsync<GetBlockchainStateResult>(FullNodeRoutes.GetBlockchainState());
            return result.BlockchainState;
        }

        public async Task<Block> GetBlockAsync(HexBytes headerHash)
        {
            var result = await PostAsync<GetBlockResult>(FullNodeRoutes.GetBlock(), new Dictionary<string, string>()
            {
                ["header_hash"] = headerHash.Hex,
            });
            return result.Block;
        }

        public async Task<Block[]> GetBlocksAsync(int startHeight, int endHeight)
        {
            var result = await PostAsync<GetBlocksResult>(FullNodeRoutes.GetBlocks(), new Dictionary<string, string>()
            {
                ["start"] = $"{startHeight}",
                ["end"] = $"{endHeight}",
            });
            return result.Blocks;
        }

        public async Task<RecentEndOfSubSlotBundle> GetRecentEndOfSubSlotBundleAsync(HexBytes challengeHash)
        {
            var result = await PostAsync<GetRecentEosResult>(FullNodeRoutes.GetRecentSignagePointOrEos(), new Dictionary<string, string>()
            {
                ["challenge_hash"] = challengeHash.Hex
            });
            return new RecentEndOfSubSlotBundle(result.EndOfSubSlotBundle, result.ReceivedAt, result.Reverted);
        }

        public async Task<RecentSignagePoint> GetRecentSignagePoint(HexBytes signagePointHash)
        {
            var result = await PostAsync<GetRecentSignagePointResult>(FullNodeRoutes.GetRecentSignagePointOrEos(), new Dictionary<string, string>()
            {
                ["sp_hash"] = signagePointHash.Hex
            });
            return new RecentSignagePoint(result.SignagePoint, result.ReceivedAt, result.Reverted);
        }

        async Task<HexBytes> IExtendedNodeRPCClient.GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId)
        {
            var result = await PostAsync<GetPayToSingletonPuzzleHashFromLauncherIdResult>(FullNodeRoutes.GetPayToSingletonPuzzleHashFromLauncherId(), new Dictionary<string, string>()
            {
                ["launcher_id"] = launcherId.Hex,
            });
            return result.PayToSingletonPuzzleHash;
        }

        async Task<bool> IExtendedNodeRPCClient.AggregateVerifyAsync(HexBytes ownerPk, HexBytes plotPk, HexBytes authPk, HexBytes serializedAuthenticationKeyInfo, HexBytes payloadHash, HexBytes signature)
        {
            var result = await PostAsync<AggregateVerifyResult>(FullNodeRoutes.AggregateVerify(), new Dictionary<string, string>()
            {
                ["owner_pk"] = $"{ownerPk}",
                ["plot_public_key"] = $"{plotPk}",
                ["authentication_public_key"] = $"{authPk}",
                ["authentication_key_info"] = $"{serializedAuthenticationKeyInfo}",
                ["payload_hash"] = $"{payloadHash}",
                ["signature"] = $"{signature}"
            });
            return result.ValidSignature;
        }

        async Task<ProofQuality> IExtendedNodeRPCClient.GetProofQualityAsync(ProofOfSpace proof)
        {
            var result = await PostAsync<GetProofQualityStringResult>(FullNodeRoutes.GetProofQualityString(), new Dictionary<string, string>()
            {
                ["plotId"] = proof.GetPlotId().Hex,
                ["size"] = $"{proof.Size}",
                ["challenge"] = proof.Challenge.Hex,
                ["proof"] = proof.Proof
            });
            return result.Valid
                ? new ProofQuality(true, result.QualityString)
                : new ProofQuality(false, HexBytes.Empty);
        }
    }
}
