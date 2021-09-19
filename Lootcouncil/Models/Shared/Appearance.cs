using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Appearance
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }


}
