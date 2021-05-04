using System;

namespace ChiaRPC.Routes
{
    internal static class FarmerRoutes
    {
        public static Uri SetRewardTargets()
            => new Uri("set_reward_targets", UriKind.Relative);
    }
}
