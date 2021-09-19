using Lootcouncil.Models.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class ProfileSummaryResponse
    {
        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("wow_accounts")]
        public List<WowAccount> WowAccounts { get; set; }

        [JsonPropertyName("collections")]
        public Collections Collections { get; set; }
    }
}