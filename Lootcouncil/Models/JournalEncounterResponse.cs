using Lootcouncil.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class JournalEncounterResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("creatures")]
        public List<Creature> Creatures { get; set; }

        [JsonPropertyName("items")]
        public List<ItemContainer> Items { get; set; }

        [JsonPropertyName("instance")]
        public Instance Instance { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("modes")]
        public List<Difficulty> Modes { get; set; }
    }

}
