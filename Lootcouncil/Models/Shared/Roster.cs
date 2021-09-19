using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Roster
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
