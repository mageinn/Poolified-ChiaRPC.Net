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
            SslCertificateDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.chia/mainnet/config/ssl";
        }
    }
}
