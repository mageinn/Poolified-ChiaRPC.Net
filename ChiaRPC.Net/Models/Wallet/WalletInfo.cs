using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class WalletInfo
    {
        [JsonPropertyName("id")]
        public uint Id { get; init; }
        [JsonPropertyName("name")]
        public string Name { get; init; }
        [JsonPropertyName("type")]
        public WalletType Type { get; init; }
        [JsonPropertyName("data")]
        public string Data { get; init; }

        public WalletInfo()
        {
        }
        public WalletInfo(uint id, string name, WalletType type, string data)
        {
            Id = id;
            Name = name;
            Type = type;
            Data = data;
        }
    }
}
