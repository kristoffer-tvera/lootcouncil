using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class EquippedItem
    {
        [JsonPropertyName("item")]
        public Item Item { get; set; }

        [JsonPropertyName("sockets")]
        public List<Socket> Sockets { get; set; }

        [JsonPropertyName("slot")]
        public Slot Slot { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("context")]
        public int Context { get; set; }

        [JsonPropertyName("bonus_list")]
        public List<int> BonusList { get; set; }

        [JsonPropertyName("quality")]
        public Quality Quality { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("modified_appearance_id")]
        public int ModifiedAppearanceId { get; set; }

        [JsonPropertyName("media")]
        public Media Media { get; set; }

        [JsonPropertyName("item_class")]
        public ItemClass ItemClass { get; set; }

        [JsonPropertyName("item_subclass")]
        public ItemSubclass ItemSubclass { get; set; }

        [JsonPropertyName("inventory_type")]
        public InventoryType InventoryType { get; set; }

        [JsonPropertyName("binding")]
        public Binding Binding { get; set; }

        [JsonPropertyName("armor")]
        public Armor Armor { get; set; }

        [JsonPropertyName("stats")]
        public List<Stat> Stats { get; set; }

        [JsonPropertyName("spells")]
        public List<SpellContainer> Spells { get; set; }

        [JsonPropertyName("sell_price")]
        public SellPrice SellPrice { get; set; }

        [JsonPropertyName("requirements")]
        public Requirements Requirements { get; set; }

        [JsonPropertyName("level")]
        public Level Level { get; set; }

        [JsonPropertyName("durability")]
        public Durability Durability { get; set; }

        [JsonPropertyName("name_description")]
        public NameDescription NameDescription { get; set; }

        [JsonPropertyName("is_subclass_hidden")]
        public bool? IsSubclassHidden { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("transmog")]
        public Transmog Transmog { get; set; }

        [JsonPropertyName("unique_equipped")]
        public string UniqueEquipped { get; set; }

        [JsonPropertyName("charges")]
        public Charges Charges { get; set; }

        [JsonPropertyName("enchantments")]
        public List<Enchantment> Enchantments { get; set; }

        [JsonPropertyName("limit_category")]
        public string LimitCategory { get; set; }

        [JsonPropertyName("weapon")]
        public Weapon Weapon { get; set; }
    }
}