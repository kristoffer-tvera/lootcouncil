using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Links
    {
        [JsonPropertyName("self")]
        public Self Self { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }
    }
}
