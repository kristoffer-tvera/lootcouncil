using Lootcouncil.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{

    public class GuildRosterResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("guild")]
        public Guild Guild { get; set; }

        [JsonPropertyName("members")]
        public List<Member> Members { get; set; }
    }
}
