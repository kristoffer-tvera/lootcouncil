using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class WowAccount
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("characters")]
        public List<Character> Characters { get; set; }
    }
}
