using System.Text.Json.Serialization;

namespace ChiaRPC.Results
{
    internal sealed class GetPlotDirectoriesResult : ChiaResult
    {
        [JsonPropertyName("directories")]
        public string[] Directories { get; init; }

        [JsonConstructor]
        public GetPlotDirectoriesResult()
        {
        }
    }
}
