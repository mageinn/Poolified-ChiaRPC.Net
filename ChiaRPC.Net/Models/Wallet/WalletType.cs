namespace ChiaRPC.Models
{
    public enum WalletType : ushort
    {
        StandardWallet = 0,
        RateLimited = 1,
        AtomicSwap = 2,
        AuthorizedPayee = 3,
        MultiSig = 4,
        Custody = 5,
        ColouredCoin = 6,
        Recoverable = 7,
        DistributedId = 8,
    }
}
