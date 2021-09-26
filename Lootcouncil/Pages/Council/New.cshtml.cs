using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Models.Db;
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
        private readonly IDbRepository _db;

        public JournalInstanceResponse Instance { get; set; }
        public List<Models.Shared.Member> Members { get; set; }
        public int DefaultMemberRankIncluded { get; set; } = 3;
        public int MaxRank { get; set; }

        [BindProperty]
        public int[] CharacterIds { get; set; } = new int[0];

        public NewModel(ILogger<NewModel> logger, IApiRepository api, IDbRepository db)
        {
            _logger = logger;
            _api = api;
            _db = db;
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

        public async Task<IActionResult> OnPostAsync(int instance)
        {
            if (!CharacterIds.Any())
            {
                ViewData["Error"] = "No members picked";
                return RedirectToPage("/Council/New", new { instance });
            }

            var region = Request.Cookies.GetRegion();
            var self = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));
            var guild = await _api.GetGuildResponse(self.Guild.Key.Href, region);
            var roster = await _api.GetGuildRosterResponse(guild.Roster.Href, region);

            var council = await _db.CreateNewCouncil(guild.Id, instance);

            var councilMembers = new List<CouncilMember>();
            foreach(var characterId in CharacterIds)
            {
                var character = roster.Members.FirstOrDefault(m => m.Character.Id == characterId);
                if(character == null)
                {
                    continue;
                }

                councilMembers.Add(new CouncilMember
                {
                    CouncilId = council.Id,
                    Name = character.Character.Name,
                    Realm = character.Character.Realm.Slug
                });

            }

            await _db.AddCouncilMembers(councilMembers);

            return RedirectToPage("/Council/Index", new { id = council.Id});
        }
    }
}
