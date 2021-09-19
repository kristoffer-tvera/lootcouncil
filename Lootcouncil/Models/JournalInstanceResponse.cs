using Lootcouncil.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class JournalInstanceResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("map")]
        public Map Map { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("encounters")]
        public List<Encounter> Encounters { get; set; }

        [JsonPropertyName("expansion")]
        public Expansion Expansion { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("modes")]
        public List<Mode> Modes { get; set; }

        [JsonPropertyName("media")]
        public Media Media { get; set; }

        [JsonPropertyName("minimum_level")]
        public int MinimumLevel { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }
    }
}
