using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class EncounterCompleted
    {
        [JsonPropertyName("encounter")]
        public Encounter Encounter { get; set; }

        [JsonPropertyName("mode")]
        public Difficulty Mode { get; set; }
    }
}