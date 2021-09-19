using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Display
    {
        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }

        [JsonPropertyName("color")]
        public Color Color { get; set; }
    }
}