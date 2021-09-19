using Lootcouncil.Models.Shared;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class ItemResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("quality")]
        public Quality Quality { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("required_level")]
        public int RequiredLevel { get; set; }

        [JsonPropertyName("media")]
        public Media Media { get; set; }

        [JsonPropertyName("item_class")]
        public ItemClass ItemClass { get; set; }

        [JsonPropertyName("item_subclass")]
        public ItemSubclass ItemSubclass { get; set; }

        [JsonPropertyName("inventory_type")]
        public InventoryType InventoryType { get; set; }

        [JsonPropertyName("purchase_price")]
        public int PurchasePrice { get; set; }

        [JsonPropertyName("sell_price")]
        public int SellPrice { get; set; }

        [JsonPropertyName("max_count")]
        public int MaxCount { get; set; }

        [JsonPropertyName("is_equippable")]
        public bool IsEquippable { get; set; }

        [JsonPropertyName("is_stackable")]
        public bool IsStackable { get; set; }

        [JsonPropertyName("purchase_quantity")]
        public int PurchaseQuantity { get; set; }
    }
}
