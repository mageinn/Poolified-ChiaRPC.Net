using ChiaRPC.Models;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public interface IExtendedNodeRPCClient : INodeRPCClient
    {
        /// <summary>
        /// Converts the a launcherId to a P2Singleton Puzzle Hash.
        /// </summary>
        /// <param name="launcherId"></param>
        /// <returns></returns>
        Task<HexBytes> GetPayToSingletonPuzzleHashFromLauncherIdAsync(HexBytes launcherId);

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
        Task<bool> AggregateVerifyAsync(HexBytes ownerPk, HexBytes plotPk, HexBytes authPk, HexBytes serializedAuthenticationKeyInfo, HexBytes payloadHash, HexBytes signature);
    }
}
