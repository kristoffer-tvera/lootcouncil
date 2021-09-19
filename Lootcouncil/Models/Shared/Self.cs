using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Self
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
