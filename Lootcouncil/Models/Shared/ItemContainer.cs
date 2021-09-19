using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class ItemContainer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("item")]
        public Item Item { get; set; }
    }

}
