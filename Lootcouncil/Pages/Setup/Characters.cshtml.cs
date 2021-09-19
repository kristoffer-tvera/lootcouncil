using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Models.Shared;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Setup
{
    public class CharactersModel : PageModel
    {
        private readonly ILogger<CharactersModel> _logger;
        private readonly IApiRepository _api;

        public IEnumerable<Character> Characters { get; set; }


        public CharactersModel(ILogger<CharactersModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var profile = await _api.GetProfileSummary("eu", accessToken);

            var characters = new List<Character>();
            foreach (var account in profile.WowAccounts)
            {
                characters.AddRange(account.Characters);
            }

            Characters = characters.Where(c => c.Level > 10).OrderBy(c => c.Realm.Slug).ThenBy(c => c.Level);
        }
    }
}
