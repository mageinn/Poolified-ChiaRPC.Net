using ChiaRPC.Models;
using ChiaRPC.Results;
using ChiaRPC.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public sealed class NodeRPCClient : ChiaRPCClient
    {
        public NodeRPCClient(ChiaRPCOptions options, string apiUrl) 
            : base(options, "full_node", apiUrl)
        {
        }

        /// <summary>
        /// Returns current information about the blockchain, including the peak, sync information, difficulty, mempool size, etc.
        /// </summary>
        /// <returns></returns>
        public async Task<BlockchainState> GetBlockchainStateAsync()
        {
            var result = await PostAsync<GetBlockchainStateResult>(FullNodeRoutes.GetBlockchainState());
            return result.BlockchainState;
        }

        /// <summary>
        /// Gets a full block by header hash.
        /// </summary>
        /// <param name="headerHash"></param>
        /// <returns></returns>
        public async Task<Block> GetBlockAsync(string headerHash)
        {
            var result = await PostAsync<GetBlockResult>(FullNodeRoutes.GetBlock(), new Dictionary<string, string>()
            {
                ["header_hash"] = headerHash,
            });
            return result.Block;
        }

        /// <summary>
        /// Gets a list of full blocks.
        /// </summary>
        /// <param name="startHeight"></param>
        /// <param name="endHeight"></param>
        /// <returns></returns>
        public async Task<Block[]> GetBlocksAsync(int startHeight, int endHeight)
        {
            var result = await PostAsync<GetBlocksResult>(FullNodeRoutes.GetBlocks(), new Dictionary<string, string>()
            {
                ["start"] = $"{startHeight}",
                ["end"] = $"{endHeight}",
            });
            return result.Blocks;
        }

        /// <summary>
        /// Gets a recent EndOfSubSlotBundle.
        /// </summary>
        /// <param name="challengeHash"></param>
        /// <returns></returns>
        public async Task<RecentEndOfSubSlotBundle> GetRecentEndOfSubSlotBundleAsync(string challengeHash)
        {
            var result = await PostAsync<GetRecentEosResult>(FullNodeRoutes.GetRecentSignagePointOrEos(), new Dictionary<string, string>()
            {
                ["challenge_hash"] = challengeHash
            });
            return new RecentEndOfSubSlotBundle(result.EndOfSubSlotBundle, result.ReceivedAt, result.Reverted);
        }

        /// <summary>
        /// Gets a recent SignagePoint.
        /// </summary>
        /// <param name="signagePointHash"></param>
        /// <returns></returns>
        public async Task<RecentSignagePoint> GetRecentSignagePoint(string signagePointHash)
        {
            var result = await PostAsync<GetRecentSignagePointResult>(FullNodeRoutes.GetRecentSignagePointOrEos(), new Dictionary<string, string>()
            {
                ["sp_hash"] = signagePointHash
            });
            return new RecentSignagePoint(result.SignagePoint, result.ReceivedAt, result.Reverted);
        }

        /// <summary>
        /// Converts the a launcherId to a P2Singleton Puzzle Hash.
        /// </summary>
        /// <param name="launcherId"></param>
        /// <returns></returns>
        public async Task<HexBytes> GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId)
        {
            var result = await PostAsync<GetPayToSingletonPuzzleHashFromLauncherIdResult>(FullNodeRoutes.GetPayToSingletonPuzzleHashFromLauncherId(), new Dictionary<string, string>()
            {
                ["launcher_id"] = launcherId.Hex,
            });
            return result.PayToSingletonPuzzleHash;
        }

        /// <summary>
        /// Verifies the signature of the payload.
        /// </summary>
        /// <param name="ownerPk"></param>
        /// <param name="plotPk"></param>
        /// <param name="authPk"></param>
        /// <param name="serializedAuthenticationKeyInfo"></param>
        /// <param name="payloadHash"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public async Task<bool> AggregateVerifyAsync(HexBytes ownerPk, HexBytes plotPk, HexBytes authPk, HexBytes serializedAuthenticationKeyInfo, HexBytes payloadHash, HexBytes signature)
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
    }
}
