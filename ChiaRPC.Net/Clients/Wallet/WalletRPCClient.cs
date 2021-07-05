using ChiaRPC.Models;
using ChiaRPC.Results;
using ChiaRPC.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public sealed class WalletRPCClient : ChiaRPCClient
    {
        public WalletRPCClient(ChiaRPCOptions options, string apiUrl) 
            : base(options, "wallet", apiUrl)
        {
        }

        /// <summary>
        /// Retrieves balances for a wallet.
        /// </summary>
        /// <returns></returns>
        public async Task<Wallet> GetWalletBalance(uint walletId)
        {
            var result = await PostAsync<GetWalletBalanceResult>(WalletRoutes.GetWalletBalance(), new Dictionary<string, string>()
            {
                ["wallet_id"] = $"{walletId}"
            });
            return result.Wallet;
        }

        /// <summary>
        /// Retrieves the address of the wallet at the given id for the current key.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetWalletAddressAsync(uint walletId, bool generateAddress)
        {
            var result = await PostAsync<GetWalletAddressResult>(WalletRoutes.GetWalletAddress(), new Dictionary<string, string>()
            {
                ["wallet_id"] = $"{walletId}",
                ["new_address"] = $"{generateAddress}"
            });
            return result.Address;
        }

        /// <summary>
        /// Creates a wallet backup file at the given file path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public async Task CreateBackupFileAsync(string filePath)
        {
            await PostAsync<ChiaResult>(WalletRoutes.CreateBackupFile(), new Dictionary<string, string>()
            {
                ["file_path"] = filePath,
            });
        }

        /// <summary>
        /// Gets a list of WalletInfos for the currently logged in key.
        /// </summary>
        /// <returns></returns>
        public async Task<WalletInfo[]> GetWalletsAsync()
        {
            var result = await PostAsync<GetWalletsResult>(WalletRoutes.GetWallets());

            return result.Wallets;
        }
    }
}
