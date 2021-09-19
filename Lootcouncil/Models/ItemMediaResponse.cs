using Lootcouncil.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class ItemMediaResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("assets")]
        public List<Asset> Assets { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
