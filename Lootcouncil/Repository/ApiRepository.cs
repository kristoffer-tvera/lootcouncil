using Lootcouncil.Models;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public class ApiRepository : IApiRepository
    {
        private RestClient _client;
        private readonly BlizzardSettings _option;
        private readonly DateTime _expiry;
        private string _accessToken;
        public ApiRepository(IOptions<BlizzardSettings> options)
        {
            _expiry = DateTime.UtcNow;
            _option = options.Value;
            _client = new RestClient();
            _client.UseSystemTextJson();
        }

        public async Task Setup(string region)
        {
            if (_expiry >= DateTime.UtcNow.AddSeconds(30))
            {
                return;
            }

            var client = new RestClient($"https://{region}.battle.net")
            {
                Authenticator = new HttpBasicAuthenticator(_option.ClientId, _option.ClientSecret)
            };

            var request = new RestRequest("/oauth/token", Method.POST);
            request.AddParameter("grant_type", "client_credentials");
            var response = await client.ExecuteAsync<AuthToken>(request);

            if (!response.IsSuccessful && response.ErrorException != null) throw response.ErrorException;

            _expiry.AddSeconds(response.Data.ExpiresIn);
            _accessToken = response.Data.AccessToken;
        }

        public async Task<JournalExpansionIndexResponse> GetJournalExpansionIndexResponse(string region)
        {
            return await ExecuteRequest<JournalExpansionIndexResponse>("data/wow/journal-expansion/index", "static", region);
        }

        public async Task<JournalExpansionResponse> GetJournalExpansionResponse(int id, string region)
        {
            return await ExecuteRequest<JournalExpansionResponse>($"data/wow/journal-expansion/{id}", "static", region);
        }

        public async Task<JournalInstanceResponse> GetJournalInstanceResponse(int id, string region)
        {
            return await ExecuteRequest<JournalInstanceResponse>($"data/wow/journal-instance/{id}", "static", region);
        }

        public async Task<JournalEncounterResponse> GetJournalEncounterResponse(int id, string region)
        {
            return await ExecuteRequest<JournalEncounterResponse>($"data/wow/journal-encounter/{id}", "static", region);
        }

        public async Task<ItemResponse> GetItemResponse(int id, string region)
        {
            return await ExecuteRequest<ItemResponse>($"/data/wow/item/{id}", "static", region);
        }

        public async Task<GuildResponse> GetGuildResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<GuildResponse>($"data/wow/guild/{realm}/{name}/roster", "profile", region);
        }

        public async Task<GuildRosterResponse> GetGuildRosterResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<GuildRosterResponse>($"data/wow/guild/{realm}/{name}/roster", "profile", region);
        }

        public async Task<GuildActivitiesResponse> GetGuildActivitiesResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<GuildActivitiesResponse>($"data/wow/guild/{realm}/{name}/activity", "profile", region);
        }

        public async Task<CharacterEquipmentResponse> GetCharacterEquipmentResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<CharacterEquipmentResponse>($"profile/wow/character/{realm}/{name}/equipment", "profile", region);
        }

        public async Task<CharacterResponse> GetCharacterResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<CharacterResponse>($"profile/wow/character/{realm}/{name}", "profile", region);
        }

        public async Task<ItemMediaResponse> GetItemMediaResponse(string itemId, string region)
        {
            return await ExecuteRequest<ItemMediaResponse>($"data/wow/media/item/{itemId}", "static", region);
        }

        public async Task<ProfileSummaryResponse> GetProfileSummary(string region, string accessToken)
        {
            return await ExecuteRequest<ProfileSummaryResponse>($"profile/user/wow", "profile", region, accessToken);
        }

        private async Task<T> ExecuteRequest<T>(string path, string ns, string region, string accessToken = "")
        {
            _client.BaseUrl = new Uri($"https://{region}.api.blizzard.com");

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                await Setup(region);
                accessToken = _accessToken;
            }

            var request = new RestRequest(path, Method.GET);
            request.AddParameter("namespace", $"{ns}-{region}");
            request.AddParameter("locale", _option.Locale);
            request.AddParameter("access_token", accessToken);
            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful && response.ErrorException != null) throw response.ErrorException;

            return response.Data;
        }
    }
}
