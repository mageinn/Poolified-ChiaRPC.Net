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
        /// <param name="ownerPk"></param>
        /// <param name="plotPk"></param>
        /// <param name="authPk"></param>
        /// <param name="serializedAuthenticationKeyInfo"></param>
        /// <param name="payloadHash"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        Task<bool> AggregateVerifySignatureAsync(HexBytes ownerPk, HexBytes plotPk, HexBytes authPk, HexBytes serializedAuthenticationKeyInfo, HexBytes payloadHash, HexBytes signature);

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
        Task<ProofQuality> GetProofQualityAsync(ProofOfSpace proof);

        /// <summary>
        /// Retrieves the delayed puzzle info from the launcher spend.
        /// </summary>
        /// <param name="coinSolution"></param>
        /// <returns></returns>
        Task<DelayedPuzzleInfo> GetDelayedPuzzleInfoFromLauncherSpendAsync(CoinSolution coinSolution);

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
    }
}
