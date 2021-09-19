using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Titles
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
