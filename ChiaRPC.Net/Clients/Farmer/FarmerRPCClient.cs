using ChiaRPC.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public sealed class FarmerRPCClient : ChiaRPCClient
    {
        public FarmerRPCClient(string farmerCertificateDirectory, string apiUrl)
            : base(farmerCertificateDirectory, "farmer", apiUrl)
        {
        }

        /// <summary>
        /// Sets the reward targets in the farmer and configuration file.
        /// </summary>
        /// <param name="targetAddress"></param>
        /// <returns></returns>
        public async Task SetRewardTargets(string targetAddress)
            => await PostAsync(FarmerRoutes.SetRewardTargets(), new Dictionary<string, string>()
            {
                ["farmer_target"] = targetAddress,
                ["pool_target"] = targetAddress,
            });
    }
}
