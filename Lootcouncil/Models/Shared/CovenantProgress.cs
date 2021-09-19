using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class CovenantProgress
    {
        [JsonPropertyName("chosen_covenant")]
        public ChosenCovenant ChosenCovenant { get; set; }

        [JsonPropertyName("renown_level")]
        public int RenownLevel { get; set; }

        [JsonPropertyName("soulbinds")]
        public Soulbinds Soulbinds { get; set; }
    }
}
