using ChiaRPC.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChiaRPC.Parsers
{
    public sealed class HexBytesConverter : JsonConverter<HexBytes>
    {
        public override HexBytes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string hexG1Element = reader.GetString();

            return string.IsNullOrWhiteSpace(hexG1Element)
                ? HexBytes.Empty
                : HexBytes.FromHex(hexG1Element);
        }

        public override void Write(Utf8JsonWriter writer, HexBytes value, JsonSerializerOptions options)
        {
            if (value.IsEmpty)
            {
                writer.WriteStringValue("");
            }
            else
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
