using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Extensions;
using Lootcouncil.Models.Shared;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Setup
{
    public class CharactersModel : PageModel
    {
        private readonly ILogger<CharactersModel> _logger;
        private readonly IApiRepository _api;

        public IEnumerable<IGrouping<string, Character>> CharactersByRealm { get; set; }


        public CharactersModel(ILogger<CharactersModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var profile = await _api.GetProfileSummary(HttpContext.Request.Cookies.GetRegion(), accessToken); ;

            var characters = new List<Character>();
            foreach (var account in profile.WowAccounts)
            {
                characters.AddRange(account.Characters);
            }

            CharactersByRealm = characters.GroupBy(c => c.Realm.Name);
        }

    }
}
