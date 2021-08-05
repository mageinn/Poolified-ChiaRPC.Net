using ChiaRPC.Models;
using ChiaRPC.Results;
using ChiaRPC.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<FullBlock> GetBlockAsync(HexBytes headerHash)
        {
            var result = await PostAsync<GetBlockResult>(FullNodeRoutes.GetBlock(), new Dictionary<string, string>()
            {
                ["header_hash"] = headerHash.Hex,
            });

            return result.Block;
        }

        public async Task<FullBlock[]> GetBlocksAsync(uint startHeight, uint endHeight)
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
            },
            throwOnError: false);

            return result != null
                ? new RecentEndOfSubSlotBundle(result.EndOfSubSlotBundle, result.ReceivedAt, result.CurrentPeakHeight, result.Reverted)
                : null;
        }

        public async Task<RecentSignagePoint> GetRecentSignagePointAsync(HexBytes signagePointHash)
        {
            var result = await PostAsync<GetRecentSignagePointResult>(FullNodeRoutes.GetRecentSignagePointOrEos(), new Dictionary<string, string>()
            {
                ["sp_hash"] = signagePointHash.Hex
            },
            throwOnError: false);

            return result != null
                ? new RecentSignagePoint(result.SignagePoint, result.ReceivedAt, result.CurrentPeakHeight, result.Reverted)
                : null;
        }

        public async Task<CoinRecord> GetCoinRecordByNameAsync(HexBytes name)
        {
            var result = await PostAsync<GetCoinRecordByNameResult>(FullNodeRoutes.GetCoinRecordByName(), new Dictionary<string, string>()
            {
                ["name"] = $"{name}"
            }, false);

            return result.CoinRecord;
        }
        public async Task<CoinSolution> GetPuzzleAndSolutionAsync(HexBytes coinId, uint height)
        {
            var result = await PostAsync<GetPuzzleAndSolutionResult>(FullNodeRoutes.GetPuzzleAndSolution(), new Dictionary<string, string>()
            {
                ["coin_id"] = $"{coinId}",
                ["height"] = $"{height}",
            });

            return result.CoinSolution;
        }

        public Task<CoinSolution> GetPuzzleAndSolutionAsync(CoinRecord coinRecord)
            => GetPuzzleAndSolutionAsync(coinRecord.Name(), coinRecord.SpentBlockIndex);

        public async Task<CoinRecord[]> GetCoinRecordsByPuzzleHashesAsync(IEnumerable<HexBytes> puzzleHashes,
            uint startHeight = 0, uint endHeight = int.MaxValue,
            bool includeSpentCoins = false, bool excludeNonCoinbase = false)
        {
            if (!puzzleHashes.Any())
            {
                return Array.Empty<CoinRecord>();
            }

            var result = await PostAsyncRaw<CoinRecordsResult>(FullNodeRoutes.GetCoinRecordsByPuzzleHashes(), new Dictionary<string, object>()
            {
                ["puzzle_hashes"] = puzzleHashes.Select(x => x.Hex),
                ["start_height"] = $"{startHeight}",
                ["end_height"] = $"{endHeight}",
                ["include_spent_coins"] = $"{includeSpentCoins}",
                ["exclude_non_coinbase"] = $"{excludeNonCoinbase}"
            });

            return result.CoinRecords;
        }

        async Task<HexBytes> IExtendedNodeRPCClient.GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId, ulong delayTime, HexBytes delayPuzzleHash)
        {
            var result = await PostAsync<GetPayToSingletonPuzzleHashFromLauncherIdResult>(FullNodeRoutes.GetPayToSingletonPuzzleHashFromLauncherId(), new Dictionary<string, string>()
            {
                ["launcher_id"] = launcherId.Hex,
                ["delay_time"] = $"{delayTime}",
                ["delay_puzzle_hash"] = delayPuzzleHash.Hex
            });

            return result.PayToSingletonPuzzleHash;
        }

        async Task<HexBytes> IExtendedNodeRPCClient.GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId, DelayedPuzzleInfo delayedPuzzleInfo)
        {
            var result = await PostAsync<GetPayToSingletonPuzzleHashFromLauncherIdResult>(FullNodeRoutes.GetPayToSingletonPuzzleHashFromLauncherId(), new Dictionary<string, string>()
            {
                ["launcher_id"] = launcherId.Hex,
                ["delay_time"] = $"{delayedPuzzleInfo.DelaySeconds}",
                ["delay_puzzle_hash"] = delayedPuzzleInfo.DelayPuzzleHash.Hex
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

        async Task<ProofQuality> IExtendedNodeRPCClient.GetProofQualityAsync(HexBytes plotId, int size, HexBytes posChallenge, HexBytes proof)
        {
            var result = await PostAsync<GetProofQualityStringResult>(FullNodeRoutes.GetProofQualityString(), new Dictionary<string, string>()
            {
                ["plot_id"] = plotId.Hex,
                ["size"] = $"{size}",
                ["challenge"] = posChallenge.Hex,
                ["proof"] = proof.Hex
            });

            return result.Valid
                ? new ProofQuality(true, result.QualityString)
                : new ProofQuality(false, HexBytes.Empty);
        }

        async Task<DelayedPuzzleInfo> IExtendedNodeRPCClient.GetDelayedPuzzleInfoFromLauncherIdAsync(HexBytes launcherId)
        {
            var result = await PostAsync<GetDelayedPuzzleInfoFromLauncherSpendResult>(FullNodeRoutes.GetDelayedPuzzleInfoFromLauncherId(), new Dictionary<string, string>()
            {
                ["launcher_id"] = launcherId.Hex,
            });

            return !result.HasValue
                ? null
                : new DelayedPuzzleInfo(
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

        async Task<bool> IExtendedNodeRPCClient.CheckRelativeLockHeightAsync(HexBytes coinId, uint relativeLockHeight)
        {
            var result = await PostAsync<ValidationResult>(FullNodeRoutes.CheckRelativeLockHeight(), new Dictionary<string, string>()
            {
                ["coin_id"] = coinId.Hex,
                ["relative_lock_height"] = $"{relativeLockHeight}"
            });

            return result.Valid;
        }

        async Task<bool> IExtendedNodeRPCClient.ConfirmSignagePointOrEosAsync(HexBytes spHash, uint hintHeight, HexBytes rewardChainChallenge, ulong challengeChainIterations)
        {
            var result = await PostAsync<ValidationResult>(FullNodeRoutes.ConfirmSignagePointOrEos(), new Dictionary<string, string>()
            {
                ["sp_hash"] = spHash.Hex,
                ["hint_height"] = $"{hintHeight}",
                ["rc_challenge"] = rewardChainChallenge.Hex,
                ["cc_iters"] = $"{challengeChainIterations}"
            });

            return result.Valid;
        }

        async Task<TxResult> IExtendedNodeRPCClient.AbsorbSingletonRewardAsync(HexBytes launcherId, CoinSolution singletonTip, PoolState poolStateTip, uint rewardConfirmedHeight, HexBytes rewardCoinParentInfo)
        {
            var result = await PostAsyncRaw<AbsorbSingletonRewardResult>(FullNodeRoutes.AbsorbSingletonReward(), new Dictionary<string, object>()
            {
                ["launcher_id"] = launcherId.Hex,
                ["singleton_tip"] = singletonTip,
                ["poolstate_tip"] = poolStateTip,
                ["reward_confirmed_height"] = rewardConfirmedHeight,
                ["reward_coin_parent_info"] = rewardCoinParentInfo.Hex
            });

            return new TxResult(result.Status, result.Error);
        }
    }
}
