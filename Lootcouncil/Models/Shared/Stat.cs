using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Stat
    {
        [JsonPropertyName("type")]
        public StatType Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("display")]
        public Display Display { get; set; }

        [JsonPropertyName("is_negated")]
        public bool? IsNegated { get; set; }

        [JsonPropertyName("is_equip_bonus")]
        public bool? IsEquipBonus { get; set; }
    }
}