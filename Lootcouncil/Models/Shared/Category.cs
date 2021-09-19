using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Category
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
