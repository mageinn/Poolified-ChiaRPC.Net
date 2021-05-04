﻿using ChiaRPC.Models;
using ChiaRPC.Results;
using ChiaRPC.Routes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiaRPC.Clients
{
    public sealed class WalletRPCClient : ChiaRPCClient
    {
        public WalletRPCClient(string walletCertificateDirectory, string apiUrl)
            : base(walletCertificateDirectory, "wallet", apiUrl)
        {
        }

        /// <summary>
        /// Retrieves balances for a wallet.
        /// </summary>
        /// <returns></returns>
        public async Task<Wallet> GetWalletBalance(int walletId)
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
        public async Task<string> GetWalletAddressAsync(int walletId, bool generateAddress)
        {
            var result = await PostAsync<GetWalletAddressResult>(WalletRoutes.GetWalletAddress(), new Dictionary<string, string>()
            {
                ["wallet_id"] = $"{walletId}",
                ["new_address"] = $"{generateAddress}"
            });
            return result.Address;
        }
    }
}
