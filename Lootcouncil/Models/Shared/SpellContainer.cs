using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class SpellContainer
    {
        [JsonPropertyName("spell")]
        public Spell Spell { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("display_color")]
        public DisplayColor DisplayColor { get; set; }
    }
}