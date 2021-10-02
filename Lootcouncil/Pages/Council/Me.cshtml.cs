using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Models.Db;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Pages.Council
{
    public class MeModel : PageModel
    {
        private readonly ILogger<MeModel> _logger;
        private readonly IDbRepository _db;
        private readonly IApiRepository _api;

        public MeModel(ILogger<MeModel> logger, IDbRepository db, IApiRepository api)
        {
            _logger = logger;
            _db = db;
            _api = api;
        }

        [BindProperty(SupportsGet = true)]
        public int CouncilId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int EncounterId { get; set; }

        public JournalInstanceResponse Instance { get; set; }
        public JournalEncounterResponse Encounter { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
        

        public async Task OnGetAsync()
        {
            var region = Request.Cookies.GetRegion();
            var council = await _db.GetCouncil(CouncilId);
            var character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));

            Entries = await _db.GetEntriesForCharacter(council.Id, character.Name, character.Realm.Slug);
            Instance = await _api.GetJournalInstanceResponse(council.InstanceId, region);
            Encounter = await _api.GetJournalEncounterResponse(EncounterId, region);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var form = await Request.ReadFormAsync();
            var character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));

            var entries = new List<Entry>();
            foreach (var entry in form)
            {
                if(int.TryParse(entry.Key, out var key) && int.TryParse(entry.Value, out var value))
                {
                    if(value == default)
                    {
                        continue;
                    }

                    entries.Add(new Entry
                    {
                        CouncilId = CouncilId,
                        ItemId = key,
                        Option = value,
                        EncounterId = EncounterId,
                        Name = character.Name,
                        Realm = character.Realm.Slug
                    });
                }
                
            }
            await _db.SaveEntries(entries);
            return RedirectToPage("/Council/Index", new { id = CouncilId });
        }
    }

}
