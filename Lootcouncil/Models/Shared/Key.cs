using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Key
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
