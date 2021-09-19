using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Media
    {
        [JsonPropertyName("key")]
        public Key Key { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
