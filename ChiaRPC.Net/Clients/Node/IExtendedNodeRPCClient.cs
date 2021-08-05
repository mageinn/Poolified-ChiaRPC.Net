using ChiaRPC.Models;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public interface IExtendedNodeRPCClient : INodeRPCClient
    {
        /// <summary>
        /// Converts the launcherId to a P2Singleton Puzzle Hash.
        /// </summary>
        /// <param name="launcherId"></param>
        /// <returns></returns>
        Task<HexBytes> GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId, ulong delayTime, HexBytes delayedPuzzleHash);

        /// <summary>
        /// Converts the launcherId to a P2Singleton Puzzle Hash.
        /// </summary>
        /// <param name="launcherId"></param>
        /// <param name="delayedPuzzleInfo"></param>
        /// <returns></returns>
        Task<HexBytes> GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId, DelayedPuzzleInfo delayedPuzzleInfo);

        /// <summary>
        /// Verifies the aggregate signature of a payload.
        /// </summary>
        /// <param name="plotPk"></param>
        /// <param name="ownerPk"></param>
        /// <param name="payloadHash"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        Task<bool> AggregateVerifySignatureAsync(HexBytes plotPk, HexBytes ownerPk, HexBytes payloadHash, HexBytes signature);

        /// <summary>
        /// Verfifies the signature of a payload.
        /// </summary>
        /// <param name="ownerPk"></param>
        /// <param name="payloadHash"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        Task<bool> VerifySignatureAsync(HexBytes ownerPk, HexBytes payloadHash, HexBytes signature);

        /// <summary>
        /// Calculates the quality string of a given proof.
        /// </summary>
        /// <param name="proof"></param>
        /// <returns></returns>
        Task<ProofQuality> GetProofQualityAsync(HexBytes plotId, int size, HexBytes posChallenge, HexBytes proof);

        /// <summary>
        /// Retrieves the delayed puzzle info from the launcher spend.
        /// </summary>
        /// <param name="coinSolution"></param>
        /// <returns></returns>
        Task<DelayedPuzzleInfo> GetDelayedPuzzleInfoFromLauncherIdAsync(HexBytes launcherId);

        /// <summary>
        /// Gets the pool state from a singleton coin spend.
        /// </summary>
        /// <param name="coinSolution"></param>
        /// <returns></returns>
        Task<PoolState> GetPoolStateFromSingletonCoinSpendAsync(CoinSolution coinSolution);

        /// <summary>
        /// Gets the current state of a singleton in the blockchain.
        /// </summary>
        /// <param name="launcherId"></param>
        /// <param name="confirmationSecurityThreshold"></param>
        /// <param name="farmerData"></param>
        /// <returns></returns>
        Task<SingletonState> GetSingletonStateAsync(HexBytes launcherId, uint confirmationSecurityThreshold, FarmerData farmerData = null);

        /// <summary>
        /// Checks if the confirmed spend height of the coinId is older than relativeLockHeight blocks.
        /// </summary>
        /// <param name="coinId"></param>
        /// <param name="relativeLockHeight"></param>
        /// <returns></returns>
        Task<bool> CheckRelativeLockHeightAsync(HexBytes coinId, uint relativeLockHeight);

        /// <summary>
        /// Confirms that a signage point has or has not been reverted.
        /// </summary>
        /// <param name="spHash"></param>
        /// <param name="hintHeight"></param>
        /// <param name="rewardChainChallenge"></param>
        /// <param name="challengeChainIterations"></param>
        /// <returns></returns>
        Task<bool> ConfirmSignagePointOrEosAsync(HexBytes spHash, uint hintHeight, HexBytes rewardChainChallenge, ulong challengeChainIterations);

        /// <summary>
        /// Absorbs a singleton reward.
        /// </summary>
        /// <param name="launcherId"></param>
        /// <param name="singletonTip"></param>
        /// <param name="poolStateTip"></param>
        /// <param name="rewardConfirmedHeight"></param>
        /// <param name="rewardCoinParentInfo"></param>
        /// <returns></returns>
        Task<AbsorbptionResult> AbsorbSingletonRewardAsync(HexBytes launcherId, CoinSolution singletonTip, PoolState poolStateTip, uint rewardConfirmedHeight, HexBytes rewardCoinParentInfo);
    }
}
