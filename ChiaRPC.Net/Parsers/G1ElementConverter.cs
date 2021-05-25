using ChiaRPC.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChiaRPC.Parsers
{
    public sealed class G1ElementConverter : JsonConverter<G1Element>
    {
        public override G1Element Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string hexG1Element = reader.GetString();

            return string.IsNullOrWhiteSpace(hexG1Element)
                ? null
                : G1Element.FromHex(hexG1Element);
        }

        public override void Write(Utf8JsonWriter writer, G1Element value, JsonSerializerOptions options)
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
