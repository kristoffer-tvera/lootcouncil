﻿using System.Text.Json.Serialization;

namespace Lootcouncil.Models.Shared
{
    public class MythicKeystoneProfile
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }


}