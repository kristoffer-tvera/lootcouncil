﻿using System.Text.Json.Serialization;

namespace Lootcouncil.Models
{
    public class AuthToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("sub")]
        public string Sub { get; set; }
    }
}
