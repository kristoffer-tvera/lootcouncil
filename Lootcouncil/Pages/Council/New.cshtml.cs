using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Council
{
    public class NewModel : PageModel
    {
        private readonly ILogger<NewModel> _logger;
        private readonly IApiRepository _api;

        public JournalInstanceResponse Instance { get; set; }
        public List<Models.Shared.Member> Members { get; set; }
        public int DefaultMemberRankIncluded { get; set; } = 3;
        public int MaxRank { get; set; }

        [BindProperty]
        public int[] CharacterId { get; set; } = new int[0];

        public NewModel(ILogger<NewModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync(int instance = -1)
        {
            if(instance < 0)
            {
                return;
            }

            var region = Request.Cookies.GetRegion();

            Instance = await _api.GetJournalInstanceResponse(instance, region);

            var character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));
            var guild = await _api.GetGuildResponse(character.Guild.Key.Href, region);

            var roster = await _api.GetGuildRosterResponse(guild.Roster.Href, region);
            MaxRank = roster.Members.Max(m => m.Rank);

            Members = roster.Members;
        }

        public async Task<IActionResult> OnPostAsync(int instance, int[] CharacterId)
        {
            var pepe = await Task.FromResult(true);
            return RedirectToPage("/Council/1");
        }
    }
}
