using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Requirements
    {
        [JsonPropertyName("level")]
        public Level Level { get; set; }
    }
}