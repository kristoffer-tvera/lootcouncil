using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Spell
    {
        [JsonPropertyName("key")]
        public Key Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}