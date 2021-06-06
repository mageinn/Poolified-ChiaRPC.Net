using ChiaRPC.Utils;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;

namespace ChiaRPC.Models
{
    public struct HexBytes
    {
        public string Hex { get; init; }
        public byte[] Bytes { get; init; }

        public bool IsEmpty => string.IsNullOrWhiteSpace(Hex);

        public HexBytes(string hex, byte[] bytes)
        {
            Hex = hex ?? string.Empty;
            Bytes = bytes ?? Array.Empty<byte>();
        }

        public HexBytes Sha256()
        {
            byte[] hash = SHA256.HashData(Bytes);
            string hexHash = HexUtils.ByteArrayToHexString(hash);
            return new HexBytes(hexHash, hash);
        }

        public static HexBytes operator +(HexBytes a, HexBytes b)
        {
            string concatHex = string.Concat(a.Hex, b.Hex);
            byte[] concatBytes = a.Bytes.Concat(b.Bytes).ToArray();

            return new HexBytes(concatHex, concatBytes);
        }
        public static bool operator ==(HexBytes a, HexBytes b) 
            => a.Hex.ToUpperInvariant() == b.Hex.ToUpperInvariant();
        public static bool operator !=(HexBytes a, HexBytes b)
            => a.Hex.ToUpperInvariant() != b.Hex.ToUpperInvariant();

        public static HexBytes FromHex(string hex) 
            => string.IsNullOrWhiteSpace(hex)
                ? Empty
                : hex.StartsWith("0x")
                    ? new HexBytes(hex[2..], HexUtils.HexStringToByteArray(hex[2..]))
                    : new HexBytes(hex, HexUtils.HexStringToByteArray(hex));

        public static HexBytes FromBytes(byte[] bytes) 
            => bytes == null
                ? Empty
                : new HexBytes(
                    HexUtils.ByteArrayToHexString(bytes),
                    bytes);

        public override bool Equals(object obj)
            => obj is HexBytes other && Hex == other.Hex;

        public override int GetHashCode()
            => HashCode.Combine(Hex);

        public override string ToString()
            => Hex;

        public static HexBytes Empty
            => new HexBytes("", Array.Empty<byte>());
    }
}
