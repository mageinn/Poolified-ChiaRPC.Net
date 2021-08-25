using ChiaRPC.Parsers;
using ChiaRPC.Utils;
using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class Coin : IStreamable
    {
        [JsonPropertyName("parent_coin_info")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes ParentCoinInfo { get; init; }

        [JsonPropertyName("puzzle_hash")]
        [JsonConverter(typeof(HexBytesConverter))]
        public HexBytes PuzzleHash { get; init; }

        [JsonPropertyName("amount")]
        public ulong Amount { get; init; }

        public Coin()
        {
        }

        public HexBytes Name()
            => Serialize().Sha256();
        public HexBytes Serialize()
            => ParentCoinInfo +
               PuzzleHash +
               IntToBytes(Amount);

        //https://github.com/Chia-Network/clvm/blob/main/clvm/casts.py#L8
        private static HexBytes IntToBytes(ulong v)
        {
            if (v == 0)
            {
                return HexBytes.Empty;
            }

            var b = BitConverter.IsLittleEndian
            ? BitConverter.GetBytes(v).Reverse()
            : BitConverter.GetBytes(v);

            while (b.Count() > 1 && b.First() == ((b.ElementAt(1) & 0x80) > 0 ? 0xFF : 0))
            {
                b = b.Skip(1);
            }

            return HexBytes.FromBytes(b.ToArray());
        }
    }
}
