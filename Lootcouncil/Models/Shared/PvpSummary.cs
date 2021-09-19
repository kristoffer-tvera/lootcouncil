using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class PvpSummary
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
