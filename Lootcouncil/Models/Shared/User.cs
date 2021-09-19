using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class User
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
