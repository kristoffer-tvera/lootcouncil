using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Quality
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
