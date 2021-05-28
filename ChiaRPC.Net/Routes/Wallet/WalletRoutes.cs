using System;

namespace ChiaRPC.Routes
{
    internal static class WalletRoutes
    {
        public static Uri GetWalletBalance()
            => new Uri("get_wallet_balance", UriKind.Relative);

        public static Uri GetWalletAddress()
            => new Uri("get_next_address", UriKind.Relative);

        public static Uri CreateBackupFile()
            => new Uri("create_backup", UriKind.Relative);

        public static Uri GetWallets()
            => new Uri("get_wallets", UriKind.Relative);
    }
}
