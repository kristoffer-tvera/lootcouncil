using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Soulbinds
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
