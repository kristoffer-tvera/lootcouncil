using System.Collections.Generic;
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
    public class PriorityModel : PageModel
    {
        private readonly ILogger<PriorityModel> _logger;
        private readonly IDbRepository _db;
        private readonly IApiRepository _api;

        public PriorityModel(ILogger<PriorityModel> logger, IDbRepository db, IApiRepository api)
        {
            _logger = logger;
            _db = db;
            _api = api;
        }

        [BindProperty(SupportsGet = true)]
        public int CouncilId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int EncounterId { get; set; }

        public JournalEncounterResponse Encounter { get; set; }
        public IEnumerable<Entry> Entries { get; set; }

        public async Task OnGetAsync()
        {
            var region = Request.Cookies.GetRegion();

            var council = await _db.GetCouncil(CouncilId);
            var guild = await _api.GetGuildRosterResponse(council.GuildRealm, council.GuildName, council.GuildRegion);

            Entries = await _db.GetEntriesForEncounter(CouncilId, EncounterId);
            Encounter = await _api.GetJournalEncounterResponse(EncounterId, region);
        }
    }
}
