using System;

namespace ChiaRPC.Clients
{
    public sealed class ChiaRPCOptions
    {
        /// <summary>
        /// The path to the base directory of the chia ssl certificates.
        /// Default paths are:
        /// Windows - %userprofile%\\.chia\\mainnet\\config\\ssl
        /// Linux - /root/.chia/mainnet/config/ssl
        /// </summary>
        public string SslCertificateDirectory { get; set; }

        public ChiaRPCOptions()
        {
            if (OperatingSystem.IsWindows())
            {
                SslCertificateDirectory = "%userprofile%\\.chia\\mainnet\\config\\ssl";
            }
            if (OperatingSystem.IsLinux())
            {
                SslCertificateDirectory = "/root/.chia/mainnet/config/ssl";
            }
        }
    }
}
