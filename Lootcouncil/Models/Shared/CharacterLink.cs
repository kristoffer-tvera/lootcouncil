using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class CharacterLink
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
