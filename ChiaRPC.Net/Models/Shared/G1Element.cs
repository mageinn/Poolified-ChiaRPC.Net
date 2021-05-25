using ChiaRPC.Utils;
using System;
using System.Linq;

namespace ChiaRPC.Models
{
    public sealed class G1Element
    {
        public byte[] PublicKey { get; init; }

        public G1Element()
        {          
        }

        public static G1Element FromHex(string hex)
        {
            return hex.StartsWith("0x")
                ? new G1Element()
                {
                    PublicKey = HexUtils.HexStringToByteArray(hex[2..])
                }
                : new G1Element()
                {
                    PublicKey = HexUtils.HexStringToByteArray(hex)
                };
        }
        public static G1Element FromBytes(byte[] bytes)
            => new G1Element()
            {
                PublicKey = bytes
            };

        public override bool Equals(object obj) 
            => obj is G1Element other && PublicKey.SequenceEqual(other.PublicKey);

        public override int GetHashCode()
            => HashCode.Combine(ToString());

        public override string ToString() 
            => HexUtils.ByteArrayToHexString(PublicKey);
    }
}
