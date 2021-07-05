using ChiaRPC.Models;
using ChiaRPC.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public sealed class FarmerRPCClient : ChiaRPCClient
    {
        public FarmerRPCClient(ChiaRPCOptions options, string apiUrl)
            : base(options, "farmer", apiUrl)
        {
        }

        /// <summary>
        /// Sets the reward targets in the farmer and configuration file.
        /// </summary>
        /// <param name="targetAddress"></param>
        /// <returns></returns>
        public async Task SetRewardTargets(HexBytes farmerTarget, HexBytes poolTarget)
            => await PostAsync(FarmerRoutes.SetRewardTargets(), new Dictionary<string, string>()
            {
                ["farmer_target"] = farmerTarget.Hex,
                ["pool_target"] = poolTarget.Hex,
            });
    }
}
