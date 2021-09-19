using Lootcouncil.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class CharacterEquipmentResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("character")]
        public Character Character { get; set; }

        [JsonPropertyName("equipped_items")]
        public List<EquippedItem> EquippedItems { get; set; }
    }
}
