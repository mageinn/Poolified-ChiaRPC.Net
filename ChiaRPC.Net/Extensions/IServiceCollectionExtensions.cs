using ChiaRPC.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace ChiaRPC.Extensions
{
    public static partial class Extensions
    {
        public static IServiceCollection ConfigureChiaRPC(this IServiceCollection services, Action<ChiaRPCOptions> configureAction)
        {
            var options = new ChiaRPCOptions();
            configureAction.Invoke(options);
            return services.AddSingleton(options);
        }

        public static IServiceCollection AddChiaFarmerClient(this IServiceCollection services, string apiUrl = "https://localhost:8559/")
        {
            services.TryAddSingleton<ChiaRPCOptions>();
            return services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<ChiaRPCOptions>();
                return new FarmerRPCClient(options, apiUrl);
            });
        }

        public static IServiceCollection AddChiaHarvesterClient(this IServiceCollection services, string apiUrl = "https://localhost:8560/")
        {
            services.TryAddSingleton<ChiaRPCOptions>();
            return services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<ChiaRPCOptions>();
                return new HarvesterRPCClient(options, apiUrl);
            });
        }

        public static IServiceCollection AddChiaNodeClient(this IServiceCollection services, string apiUrl = "https://localhost:8555/")
        {
            services.TryAddSingleton<ChiaRPCOptions>();
            return services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<ChiaRPCOptions>();
                return new NodeRPCClient(options, apiUrl);
            });
        }

        public static IServiceCollection AddChiaWalletClient(this IServiceCollection services, string apiUrl = "https://localhost:9256/")
        {
            services.TryAddSingleton<ChiaRPCOptions>();
            return services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<ChiaRPCOptions>();
                return new WalletRPCClient(options, apiUrl);
            });
        }
    }
}
