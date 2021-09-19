using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Activity
    {
        [JsonPropertyName("character_achievement")]
        public CharacterAchievement CharacterAchievement { get; set; }

        [JsonPropertyName("activity")]
        public ActivityType ActivityType { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("encounter_completed")]
        public EncounterCompleted EncounterCompleted { get; set; }
    }
}