using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Armor
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("display")]
        public Display Display { get; set; }
    }
}