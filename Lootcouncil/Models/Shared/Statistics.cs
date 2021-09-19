using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Statistics
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }


}
