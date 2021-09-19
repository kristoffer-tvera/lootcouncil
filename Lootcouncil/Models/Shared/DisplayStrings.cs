using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class DisplayStrings
    {
        [JsonPropertyName("header")]
        public string Header { get; set; }

        [JsonPropertyName("gold")]
        public string Gold { get; set; }

        [JsonPropertyName("silver")]
        public string Silver { get; set; }

        [JsonPropertyName("copper")]
        public string Copper { get; set; }
    }
}