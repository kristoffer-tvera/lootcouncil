using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class ActivityFeed
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
