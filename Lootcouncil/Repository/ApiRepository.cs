using Lootcouncil.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public class ApiRepository : IApiRepository
    {
        private RestClient _client;
        private readonly BlizzardSettings _option;
        private readonly DateTime _expiry;
        private string _accessToken;
        private readonly IMemoryCache _cache;
        public ApiRepository(IOptions<BlizzardSettings> options, IMemoryCache cache)
        {
            _expiry = DateTime.UtcNow;
            _option = options.Value;
            _client = new RestClient();
            //_client.UseSystemTextJson();
            _cache = cache;
        }

        public async Task Setup(string region = "")
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                region = Constants.Regions.First();
            }

            if (_expiry >= DateTime.UtcNow.AddSeconds(30))
            {
                return;
            }

            var client = new RestClient($"https://{region}.battle.net")
            {
                Authenticator = new HttpBasicAuthenticator(_option.ClientId, _option.ClientSecret)
            };

            var request = new RestRequest("/oauth/token", Method.Post);
            request.AddParameter("grant_type", "client_credentials");
            var response = await client.ExecuteAsync<AuthToken>(request);

            if (!response.IsSuccessful && response.ErrorException != null) throw response.ErrorException;

            _expiry.AddSeconds(response.Data.ExpiresIn);
            _accessToken = response.Data.AccessToken;
        }

        public async Task<JournalExpansionIndexResponse> GetJournalExpansionIndexResponse(string region)
        {
            return await ExecuteRequest<JournalExpansionIndexResponse>(Constants.CachePolicyAggresive, "data/wow/journal-expansion/index", "static", region); ;
        }

        public async Task<JournalExpansionResponse> GetJournalExpansionResponse(int id, string region)
        {
            return await ExecuteRequest<JournalExpansionResponse>(Constants.CachePolicyHardcore, $"data/wow/journal-expansion/{id}", "static", region);
        }

        public async Task<JournalInstanceResponse> GetJournalInstanceResponse(int id, string region)
        {
            return await ExecuteRequest<JournalInstanceResponse>(Constants.CachePolicyHardcore, $"data/wow/journal-instance/{id}", "static", region);
        }

        public async Task<JournalEncounterResponse> GetJournalEncounterResponse(int id, string region)
        {
            return await ExecuteRequest<JournalEncounterResponse>(Constants.CachePolicyHardcore, $"data/wow/journal-encounter/{id}", "static", region);
        }

        public async Task<ItemResponse> GetItemResponse(int id, string region)
        {
            return await ExecuteRequest<ItemResponse>(Constants.CachePolicyHardcore, $"/data/wow/item/{id}", "static", region);
        }

        public async Task<GuildResponse> GetGuildResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<GuildResponse>(Constants.CachePolicyLight, $"data/wow/guild/{realm}/{name}", "profile", region);
        }

        public async Task<GuildResponse> GetGuildResponse(string href, string region)
        {
            return await ExecuteRequest<GuildResponse>(Constants.CachePolicyLight, href, region);
        }

        public async Task<GuildRosterResponse> GetGuildRosterResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<GuildRosterResponse>(Constants.CachePolicyLight, $"data/wow/guild/{realm}/{name}/roster", "profile", region);
        }

        public async Task<GuildRosterResponse> GetGuildRosterResponse(string href, string region)
        {
            return await ExecuteRequest<GuildRosterResponse>(Constants.CachePolicyLight, href, region);
        }

        public async Task<GuildActivitiesResponse> GetGuildActivitiesResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<GuildActivitiesResponse>(Constants.CachePolicyLax, $"data/wow/guild/{realm}/{name}/activity", "profile", region);
        }

        public async Task<GuildActivitiesResponse> GetGuildActivitiesResponse(string href, string region)
        {
            return await ExecuteRequest<GuildActivitiesResponse>(Constants.CachePolicyLax, href, region);
        }

        public async Task<CharacterEquipmentResponse> GetCharacterEquipmentResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<CharacterEquipmentResponse>(Constants.CachePolicyLax, $"profile/wow/character/{realm}/{name}/equipment", "profile", region);
        }

        public async Task<CharacterResponse> GetCharacterResponse(string realm, string name, string region)
        {
            return await ExecuteRequest<CharacterResponse>(Constants.CachePolicyLax, $"profile/wow/character/{realm}/{name}", "profile", region);
        }

        public async Task<ItemMediaResponse> GetItemMediaResponse(string itemId, string region)
        {
            return await ExecuteRequest<ItemMediaResponse>(Constants.CachePolicyHardcore, $"data/wow/media/item/{itemId}", "static", region);
        }

        public async Task<ProfileSummaryResponse> GetProfileSummary(string region, string accessToken)
        {
            return await ExecuteRequest<ProfileSummaryResponse>(Constants.CachePolicyLax, $"profile/user/wow", "profile", region, accessToken);
        }

        /// <summary>
        /// Wrapping api call in a cached filter to avoid unneccesary calls to api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheTime"></param>
        /// <param name="path"></param>
        /// <param name="ns"></param>
        /// <param name="region"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private async Task<T> ExecuteRequest<T>(int cacheTime, string path, string ns, string region, string accessToken = "")
        {
            var cacheKey = string.Concat(path, ns, region, accessToken);
            if (_cache.TryGetValue<T>(cacheKey, out var response) && response != null)
            {
                return response;
            }

            response = await ExecuteRequest<T>(path, ns, region, accessToken);
            _cache.Set(cacheKey, response, DateTime.Now.AddSeconds(cacheTime));
            return response;
        }

        private async Task<T> ExecuteRequest<T>(string path, string ns, string region, string accessToken = "")
        {
            //_client.BaseUrl = new Uri($"https://{region}.api.blizzard.com");
            var _client = new RestClient(new Uri($"https://{region}.api.blizzard.com"));


            if (string.IsNullOrWhiteSpace(accessToken))
            {
                await Setup(region);
                accessToken = _accessToken;
            }

            var request = new RestRequest(path.ToLower(), Method.Get);
            request.AddParameter("namespace", $"{ns}-{region}");
            request.AddParameter("locale", _option.Locale);
            request.AddParameter("access_token", accessToken);
            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful && response.ErrorException != null) throw response.ErrorException;

            return response.Data;
        }

        /// <summary>
        /// Wrapping api call in a cached filter to avoid unneccesary calls to api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheTime"></param>
        /// <param name="href"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        private async Task<T> ExecuteRequest<T>(int cacheTime, string href, string region)
        {
            var cacheKey = string.Concat(href, region);
            if (_cache.TryGetValue<T>(cacheKey, out var response))
            {
                return response;
            }

            response = await ExecuteRequest<T>(href, region);
            _cache.Set(cacheKey, response, DateTime.Now.AddSeconds(cacheTime));
            return response;
        }

        private async Task<T> ExecuteRequest<T>(string href, string region)
        {
            var uri = new Uri(href);
            await Setup(region);

            //_client.BaseUrl = new Uri(uri.GetLeftPart(UriPartial.Authority));
            var _client = new RestClient(new Uri(uri.GetLeftPart(UriPartial.Authority)));

            var request = new RestRequest(uri.PathAndQuery, Method.Get);
            request.AddParameter("locale", _option.Locale);
            request.AddParameter("access_token", _accessToken);

            var response = await _client.ExecuteAsync<T>(request);
            if (!response.IsSuccessful && response.ErrorException != null) throw response.ErrorException;
            return response.Data;
        }
    }
}
