using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Dps
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }
    }
}