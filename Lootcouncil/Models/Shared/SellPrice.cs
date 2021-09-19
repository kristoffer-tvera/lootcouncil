using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class SellPrice
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("display_strings")]
        public DisplayStrings DisplayStrings { get; set; }
    }
}