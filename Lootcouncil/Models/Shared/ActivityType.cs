using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class ActivityType
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}