namespace ChiaRPC.Models
{
    public enum PoolSingletonState : byte
    {
        SelfPooling = 1,
        LeavingPool = 2,
        FarmingToPool = 3,
    }
}
