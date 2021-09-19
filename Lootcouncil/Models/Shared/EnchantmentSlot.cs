using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class EnchantmentSlot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}