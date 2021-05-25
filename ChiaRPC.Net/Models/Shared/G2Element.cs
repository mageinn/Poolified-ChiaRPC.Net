using ChiaRPC.Utils;
using System;
using System.Linq;

namespace ChiaRPC.Models
{
    public sealed class G2Element
    {
        public byte[] Signature { get; init; }

        public G2Element()
        {
        }

        public static G2Element FromHex(string hex)
        {
            return hex.StartsWith("0x")
                ? new G2Element()
                {
                    Signature = HexUtils.HexStringToByteArray(hex[2..])
                }
                : new G2Element()
                {
                    Signature = HexUtils.HexStringToByteArray(hex)
                };
        }
        public static G2Element FromBytes(byte[] bytes)
            => new G2Element()
            {
                Signature = bytes
            };

        public override bool Equals(object obj)
            => obj is G2Element other && Signature.SequenceEqual(other.Signature);

        public override int GetHashCode()
            => HashCode.Combine(ToString());

        public override string ToString()
            => HexUtils.ByteArrayToHexString(Signature);
    }
}
