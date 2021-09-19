using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Asset
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("file_data_id")]
        public int FileDataId { get; set; }
    }
}
