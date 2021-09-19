using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Level
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }
    }
}