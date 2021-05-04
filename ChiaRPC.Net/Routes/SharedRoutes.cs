using System;

namespace ChiaRPC.Routes
{
    internal static class SharedRoutes
    {
        public static Uri GetConnections()
            => new Uri("get_connections");
    }
}
