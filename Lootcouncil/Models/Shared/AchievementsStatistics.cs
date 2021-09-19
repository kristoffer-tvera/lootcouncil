using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class AchievementsStatistics
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
