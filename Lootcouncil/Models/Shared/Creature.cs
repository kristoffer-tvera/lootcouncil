using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Creature
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creature_display")]
        public CreatureDisplay CreatureDisplay { get; set; }
    }

}
