using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Professions
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
