using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Models.Shared;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lootcouncil.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiRepository _api;

        public bool IsLoggedIn { get; set; }
        public string CharacterName { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {
            var uri = new Uri("https://eu.api.blizzard.com/data/wow/guild/stormscale/amused-to-death/roster?namespace=profile-eu&locale=en_GB");


            IsLoggedIn = User.Identity.IsAuthenticated;
            var character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));
            if(character == null)
            {
                var name = Request.Cookies[Constants.CookieCharacter];
                var realm = Request.Cookies[Constants.CookieRealm];
                character = await GetCurrentCharacter(name, realm);
            }

            if(character != null)
            {
                CharacterName = character.Name;
            }
        }

        private async Task<CharacterResponse> GetCurrentCharacter(string name, string realm)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return null;
            }

            var region = Request.Cookies.GetRegion();
            var profile = await _api.GetProfileSummary(region, accessToken);

            Character character = null;
            foreach (var account in profile.WowAccounts)
            {
                character = account
                    .Characters
                    .FirstOrDefault(c =>    string.Equals(c.Name, name, StringComparison.InvariantCultureIgnoreCase) && 
                                            string.Equals(c.Realm.Slug, realm, StringComparison.InvariantCultureIgnoreCase));
                if (character != null)
                {
                    break;
                }
            }

            if(character == null)
            {
                return null;
            }

            var characterResponse = await _api.GetCharacterResponse(character.Realm.Slug, character.Name, region);

            HttpContext.Session.Set(nameof(CharacterResponse), characterResponse);
            return characterResponse;
        }
    }
}
