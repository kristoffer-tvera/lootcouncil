using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Webhook
{
    public class Embed
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("color")]
        public int Color { get; set; }

        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }
    }
}
