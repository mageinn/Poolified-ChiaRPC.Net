using System.Text.Json.Serialization;

namespace ChiaRPC.Models
{
    public sealed class SignagePoint
    {
        [JsonPropertyName("cc_vdf")]
        public VdfInfo CC_Vdf { get; init; }

        [JsonPropertyName("cc_proof")]
        public VdfProof CC_Proof { get; init; }

        [JsonPropertyName("rc_vdf")]
        public VdfInfo RC_Vdf { get; init; }

        [JsonPropertyName("rc_proof")]
        public VdfProof RC_Proof { get; init; }

        public SignagePoint()
        {
        }
    }
}
