using ChiaRPC.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChiaRPC.Parsers
{
    public sealed class G2ElementConverter : JsonConverter<G2Element>
    {
        public override G2Element Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string hexG2Element = reader.GetString();

            return string.IsNullOrWhiteSpace(hexG2Element)
                ? null
                : G2Element.FromHex(hexG2Element);
        }

        public override void Write(Utf8JsonWriter writer, G2Element value, JsonSerializerOptions options)
        {
            if (value == null)
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
