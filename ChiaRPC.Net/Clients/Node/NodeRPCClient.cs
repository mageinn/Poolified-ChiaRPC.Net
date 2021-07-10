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

        public async Task<Block[]> GetBlocksAsync(uint startHeight, uint endHeight)
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

        public async Task<CoinRecord> GetCoinRecordByNameAsync(HexBytes name)
        {
            var result = await PostAsync<GetCoinRecordByNameResult>(FullNodeRoutes.GetCoinRecordByName(), new Dictionary<string, string>()
            {
                ["name"] = $"{name}"
            }, false);

            return result.CoinRecord;
        }
        public async Task<CoinSolution> GetPuzzleAndSolution(HexBytes coinId, ulong height)
        {
            var result = await PostAsync<GetPuzzleAndSolutionResult>(FullNodeRoutes.GetPuzzleAndSolution(), new Dictionary<string, string>()
            {
                ["coin_id"] = $"{coinId}",
                ["height"] = $"{height}",
            });

            return result.CoinSolution;
        }

        public Task<CoinSolution> GetPuzzleAndSolution(CoinRecord coinRecord)
            => GetPuzzleAndSolution(coinRecord.Name(), coinRecord.SpentBlockIndex);

        async Task<HexBytes> IExtendedNodeRPCClient.GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId, ulong seconds, HexBytes delayedPuzzleHash)
        {
            var result = await PostAsync<GetPayToSingletonPuzzleHashFromLauncherIdResult>(FullNodeRoutes.GetPayToSingletonPuzzleHashFromLauncherId(), new Dictionary<string, string>()
            {
                ["launcher_id"] = launcherId.Hex,
                ["seconds"] = $"{seconds}",
                ["delayed_puzzle_hash"] = delayedPuzzleHash.Hex
            });

            return result.PayToSingletonPuzzleHash;
        }

        async Task<HexBytes> IExtendedNodeRPCClient.GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId, DelayedPuzzleInfo delayedPuzzleInfo)
        {
            var result = await PostAsync<GetPayToSingletonPuzzleHashFromLauncherIdResult>(FullNodeRoutes.GetPayToSingletonPuzzleHashFromLauncherId(), new Dictionary<string, string>()
            {
                ["launcher_id"] = launcherId.Hex,
                ["seconds"] = $"{delayedPuzzleInfo.DelaySeconds}",
                ["delayed_puzzle_hash"] = delayedPuzzleInfo.DelayPuzzleHash.Hex
            });

            return result.PayToSingletonPuzzleHash;
        }

        async Task<bool> IExtendedNodeRPCClient.AggregateVerifySignatureAsync(HexBytes plotPk, HexBytes ownerPk, HexBytes payloadHash, HexBytes signature)
        {
            var result = await PostAsync<ValidationResult>(FullNodeRoutes.AggregateVerifySignature(), new Dictionary<string, string>()
            {
                ["plot_public_key"] = $"{plotPk}",
                ["owner_pk"] = $"{ownerPk}",
                ["payload_hash"] = $"{payloadHash}",
                ["signature"] = $"{signature}"
            });

            return result.Valid;
        }

        async Task<bool> IExtendedNodeRPCClient.VerifySignatureAsync(HexBytes ownerPk, HexBytes payloadHash, HexBytes signature)
        {
            var result = await PostAsync<ValidationResult>(FullNodeRoutes.VerifySignature(), new Dictionary<string, string>()
            {
                ["owner_pk"] = $"{ownerPk}",
                ["payload_hash"] = $"{payloadHash}",
                ["signature"] = $"{signature}",
            });

            return result.Valid;
        }

        async Task<ProofQuality> IExtendedNodeRPCClient.GetProofQualityAsync(ProofOfSpace proof)
        {
            var result = await PostAsync<GetProofQualityStringResult>(FullNodeRoutes.GetProofQualityString(), new Dictionary<string, string>()
            {
                ["plot_id"] = proof.GetPlotId().Hex,
                ["size"] = $"{proof.Size}",
                ["challenge"] = proof.Challenge.Hex,
                ["proof"] = proof.Proof.Hex
            });

            return result.Valid
                ? new ProofQuality(true, result.QualityString)
                : new ProofQuality(false, HexBytes.Empty);
        }

        async Task<DelayedPuzzleInfo> IExtendedNodeRPCClient.GetDelayedPuzzleInfoFromLauncherSpendAsync(CoinSolution coinSolution)
        {
            var result = await PostAsyncRaw<GetDelayedPuzzleInfoFromLauncherSpendResult>(FullNodeRoutes.GetDelayedPuzzleInfoFromLauncherSpend(), coinSolution);

            return new DelayedPuzzleInfo(
                result.Seconds,
                result.DelayedPuzzleHash
            );
        }

        async Task<PoolState> IExtendedNodeRPCClient.GetPoolStateFromSingletonCoinSpendAsync(CoinSolution coinSolution)
        {
            var result = await PostAsyncRaw<PoolStateResult>(FullNodeRoutes.GetPoolStateFromSingletonCoinSpend(), coinSolution);

            return result.HasValue
                ? result.PoolState
                : null;
        }

        async Task<SingletonState> IExtendedNodeRPCClient.GetSingletonStateAsync(HexBytes launcherId, uint confirmationSecurityThreshold, FarmerData farmerData)
        {
            bool hasFarmerData = farmerData != null;

            var parameters = new Dictionary<string, object>()
            {
                ["launcher_id"] = launcherId.Hex,
                ["confirmation_security_threshold"] = $"{confirmationSecurityThreshold}",
                ["has_farmer_data"] = $"{hasFarmerData}",
            };

            if (hasFarmerData)
            {
                parameters.Add("singleton_tip", farmerData.LastSolution);
                parameters.Add("singleton_tip_state", farmerData.SavedState);
                parameters.Add("delay_time", farmerData.DelayTime);
                parameters.Add("delay_puzzle_hash", farmerData.DelayPuzzleHash.Hex);
            }

            var result = await PostAsyncRaw<SingletonStateResult>(FullNodeRoutes.GetSingletonState(), parameters);

            return result.HasValue 
                ? result.SingletonState 
                : null;
        }

        async Task<bool> IExtendedNodeRPCClient.CheckRelativeLockHeight(HexBytes coinId, uint relativeLockHeight)
        {
            var result = await PostAsync<ValidationResult>(FullNodeRoutes.CheckRelativeLockHeight(), new Dictionary<string, string>()
            {
                ["coin_id"] = coinId.Hex,
                ["relative_lock_height"] = $"{relativeLockHeight}"
            });

            return result.Valid;
        }
    }
}
