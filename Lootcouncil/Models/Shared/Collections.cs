﻿using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class Collections
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }
}
