using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Charges
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }
    }
}