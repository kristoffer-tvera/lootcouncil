using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Webhook
{
    public class Field
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("inline")]
        public bool Inline { get; set; } = true;
    }
}
