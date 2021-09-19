using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Enchantment
    {
        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }

        [JsonPropertyName("source_item")]
        public SourceItem SourceItem { get; set; }

        [JsonPropertyName("enchantment_id")]
        public int EnchantmentId { get; set; }

        [JsonPropertyName("enchantment_slot")]
        public EnchantmentSlot EnchantmentSlot { get; set; }
    }
}