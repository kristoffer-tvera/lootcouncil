using System.Collections.Generic;
using System.Text.Json.Serialization;
using Lootcouncil.Models.Shared;

namespace Lootcouncil.Models
{
    public class GuildActivitiesResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("guild")]
        public Guild Guild { get; set; }

        [JsonPropertyName("activities")]
        public List<Activity> Activities { get; set; }
    }
}