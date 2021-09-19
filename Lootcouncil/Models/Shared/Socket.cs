using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Socket
    {
        [JsonPropertyName("socket_type")]
        public SocketType SocketType { get; set; }

        [JsonPropertyName("item")]
        public Item Item { get; set; }

        [JsonPropertyName("context")]
        public int Context { get; set; }

        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }

        [JsonPropertyName("media")]
        public Media Media { get; set; }

        [JsonPropertyName("display_color")]
        public DisplayColor DisplayColor { get; set; }
    }
}