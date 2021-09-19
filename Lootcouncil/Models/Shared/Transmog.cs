using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Transmog
    {
        [JsonPropertyName("item")]
        public Item Item { get; set; }

        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }

        [JsonPropertyName("item_modified_appearance_id")]
        public int ItemModifiedAppearanceId { get; set; }
    }
}