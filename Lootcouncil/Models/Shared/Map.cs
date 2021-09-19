﻿using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Map
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
