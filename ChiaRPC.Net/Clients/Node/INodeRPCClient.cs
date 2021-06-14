using ChiaRPC.Models;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public interface INodeRPCClient
    {
        /// <summary>
        /// Returns current information about the blockchain, including the peak, sync information, difficulty, mempool size, etc.
        /// </summary>
        /// <returns></returns>
        Task<BlockchainState> GetBlockchainStateAsync();

        /// <summary>
        /// Gets a full block by header hash.
        /// </summary>
        /// <param name="headerHash"></param>
        /// <returns></returns>
        Task<Block> GetBlockAsync(HexBytes headerHash);

        /// <summary>
        /// Gets a list of full blocks.
        /// </summary>
        /// <param name="startHeight"></param>
        /// <param name="endHeight"></param>
        /// <returns></returns>
        Task<Block[]> GetBlocksAsync(int startHeight, int endHeight);

        /// <summary>
        /// Gets a recent EndOfSubSlotBundle.
        /// </summary>
        /// <param name="challengeHash"></param>
        /// <returns></returns>
        Task<RecentEndOfSubSlotBundle> GetRecentEndOfSubSlotBundleAsync(HexBytes challengeHash);

        /// <summary>
        /// Gets a recent SignagePoint.
        /// </summary>
        /// <param name="signagePointHash"></param>
        /// <returns></returns>
        Task<RecentSignagePoint> GetRecentSignagePoint(HexBytes signagePointHash);
    }
}
