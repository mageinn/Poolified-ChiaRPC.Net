using ChiaRPC.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace ChiaRPC.Extensions
{
    public static partial class Extensions
    {
        public static IServiceCollection AddChiaFarmerClient(this IServiceCollection services, string farmerCertificateDirectory = "/root/.chia/mainnet/config/ssl", string apiUrl = "https://localhost:8559/")
            => services.AddSingleton(provider => new FarmerRPCClient(farmerCertificateDirectory, apiUrl));
        public static IServiceCollection AddChiaHarvesterClient(this IServiceCollection services, string harvesterCertificateDirectory = "/root/.chia/mainnet/config/ssl", string apiUrl = "https://localhost:8560/")
            => services.AddSingleton(provider => new HarvesterRPCClient(harvesterCertificateDirectory, apiUrl));
        public static IServiceCollection AddChiaNodeClient(this IServiceCollection services, string nodeCertificateDirectory = "/root/.chia/mainnet/config/ssl", string apiUrl = "https://localhost:8555/")
            => services.AddSingleton(provider => new NodeRPCClient(nodeCertificateDirectory, apiUrl));
        public static IServiceCollection AddChiaWalletClient(this IServiceCollection services, string walletCertificateDirectory = "/root/.chia/mainnet/config/ssl", string apiUrl = "https://localhost:9256/")
            => services.AddSingleton(provider => new WalletRPCClient(walletCertificateDirectory, apiUrl));
    }
}
