using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Character
    {
        [JsonPropertyName("character")]
        public CharacterLink CharacterLink { get; set; }

        [JsonPropertyName("key")]
        public Key Key { get; set; }

        [JsonPropertyName("protected_character")]
        public ProtectedCharacter ProtectedCharacter { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("realm")]
        public Realm Realm { get; set; }

        [JsonPropertyName("playable_class")]
        public PlayableClass PlayableClass { get; set; }

        [JsonPropertyName("playable_race")]
        public PlayableRace PlayableRace { get; set; }

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("faction")]
        public Faction Faction { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }
    }
}
