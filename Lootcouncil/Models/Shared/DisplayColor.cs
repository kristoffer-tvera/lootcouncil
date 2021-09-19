using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class DisplayColor
    {
        [JsonPropertyName("r")]
        public int R { get; set; }

        [JsonPropertyName("g")]
        public int G { get; set; }

        [JsonPropertyName("b")]
        public int B { get; set; }

        [JsonPropertyName("a")]
        public double A { get; set; }
    }
}