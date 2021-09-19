using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Member
    {
        [JsonPropertyName("character")]
        public Character Character { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }
    }
}
