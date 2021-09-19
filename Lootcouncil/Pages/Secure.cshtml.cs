using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Models.Shared;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages
{
    [Authorize]
    public class SecureModel : PageModel
    {
        private readonly IApiRepository _api;
        private readonly ILogger<SecureModel> _logger;
        public IEnumerable<Character> Characters { get; set; }

        public SecureModel(ILogger<SecureModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var profile = await _api.GetProfileSummary("eu", accessToken);

            var characters = new List<Character>();
            foreach(var account in profile.WowAccounts)
            {
                characters.AddRange(account.Characters);
            }

            Characters = characters.OrderBy(c => c.Realm.Slug).ThenBy(c => c.Level);
        }
    }
}
