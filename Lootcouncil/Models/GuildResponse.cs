using Lootcouncil.Models.Shared;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class GuildResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("faction")]
        public Faction Faction { get; set; }

        [JsonPropertyName("achievement_points")]
        public int AchievementPoints { get; set; }

        [JsonPropertyName("member_count")]
        public int MemberCount { get; set; }

        [JsonPropertyName("realm")]
        public Realm Realm { get; set; }

        [JsonPropertyName("roster")]
        public Roster Roster { get; set; }

        [JsonPropertyName("achievements")]
        public Achievements Achievements { get; set; }

        [JsonPropertyName("created_timestamp")]
        public long CreatedTimestamp { get; set; }

        [JsonPropertyName("activity")]
        public ActivityFeed Activity { get; set; }
    }
}
