using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class VdfProof
    {
        [JsonPropertyName("witness")]
        public string Witness { get; init; }

        [JsonPropertyName("witness_type")]
        public ushort WitnessType { get; init; }

        [JsonPropertyName("normalized_to_identity")]
        public bool NormalizedToIdentity { get; init; }

        public VdfProof()
        {
        }
    }
}
