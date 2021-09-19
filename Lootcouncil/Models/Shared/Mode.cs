using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Mode
    {
        [JsonPropertyName("mode")]
        public Difficulty Difficulty { get; set; }

        [JsonPropertyName("players")]
        public int Players { get; set; }

        [JsonPropertyName("is_tracked")]
        public bool IsTracked { get; set; }
    }
}
