using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Profile
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
