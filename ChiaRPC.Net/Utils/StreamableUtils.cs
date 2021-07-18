using ChiaRPC.Models;
using System;
using System.Linq;
using System.Text;

namespace ChiaRPC.Utils
{
    public static class StreamableUtils
    {
        public static HexBytes WithOptional(HexBytes content)
            => !content.IsEmpty
                ? HexBytes.FromHex("01" + content.Hex)
                : HexBytes.FromHex("00");

        public static HexBytes WithLength(HexBytes content)
            => !content.IsEmpty
                ? Serialize(content.Bytes.Length) + content
                : Serialize(0);

        public static HexBytes Serialize(string s)
            => HexBytes.FromBytes(Encoding.UTF8.GetBytes(s));

        public static HexBytes Serialize(bool b)
            => HexBytes.FromBytes(new byte[] { b ? (byte)1 : (byte)0 });

        public static HexBytes Serialize(byte b)
            => HexBytes.FromBytes(new byte[] { b });

        public static HexBytes Serialize(int number)
        {
            byte[] bytes = BitConverter.GetBytes(number);

            return HexBytes.FromBytes(BitConverter.IsLittleEndian
                ? bytes.Reverse().ToArray()
                : bytes);
        }
        public static HexBytes Serialize(int? number)
            => !number.HasValue ? HexBytes.Empty : Serialize(number.Value);

        public static HexBytes Serialize(long number)
        {
            byte[] bytes = BitConverter.GetBytes(number);

            return HexBytes.FromBytes(BitConverter.IsLittleEndian
                ? bytes.Reverse().ToArray()
                : bytes);
        }
        public static HexBytes Serialize(long? number)
            => !number.HasValue ? HexBytes.Empty : Serialize(number.Value);

        public static HexBytes Serialize(ulong number)
        {
            byte[] bytes = BitConverter.GetBytes(number);

            return HexBytes.FromBytes(BitConverter.IsLittleEndian
                ? bytes.Reverse().ToArray()
                : bytes);
        }
        public static HexBytes Serialize(ulong? number)
            => !number.HasValue ? HexBytes.Empty : Serialize(number.Value);
    }
}
