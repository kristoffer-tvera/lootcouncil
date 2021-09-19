using Lootcouncil.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class JournalExpansionResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("dungeons")]
        public List<Dungeon> Dungeons { get; set; }

        [JsonPropertyName("raids")]
        public List<Raid> Raids { get; set; }
    }
}
