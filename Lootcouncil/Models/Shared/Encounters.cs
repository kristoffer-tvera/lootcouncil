using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Encounters
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
