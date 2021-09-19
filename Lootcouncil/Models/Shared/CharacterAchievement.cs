using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class CharacterAchievement
    {
        [JsonPropertyName("character")]
        public Character Character { get; set; }

        [JsonPropertyName("achievement")]
        public Achievement Achievement { get; set; }
    }
}