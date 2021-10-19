using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Webhook
{
    public class Request
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
        
        [JsonPropertyName("embeds")]
        public List<Embed> Embeds { get; set; }
    }
}
