using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class ProtectedCharacter
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
