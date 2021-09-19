using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Weapon
    {
        [JsonPropertyName("damage")]
        public Damage Damage { get; set; }

        [JsonPropertyName("attack_speed")]
        public AttackSpeed AttackSpeed { get; set; }

        [JsonPropertyName("dps")]
        public Dps Dps { get; set; }
    }
}