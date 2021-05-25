using System.Text;

namespace ChiaRPC.Utils
{
    public static class HexUtils
    {
        private const string HexAlphabet = "0123456789ABCDEF";
        private static readonly int[] HexValues = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
                                                              0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                                              0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

        public static string ByteArrayToHexString(byte[] bytes)
        {
            var result = new StringBuilder(bytes.Length * 2);

            foreach (byte b in bytes)
            {
                result.Append(HexAlphabet[b >> 4]);
                result.Append(HexAlphabet[b & 0xF]);
            }

            return result.ToString();
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int x = 0, i = 0; i < hex.Length; i += 2, x += 1)
            {
                bytes[x] = (byte)((HexValues[char.ToUpper(hex[i + 0]) - '0'] << 4) |
                                   HexValues[char.ToUpper(hex[i + 1]) - '0']);
            }

            return bytes;
        }
    }
}
