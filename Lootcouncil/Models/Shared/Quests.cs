﻿using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Quests
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
