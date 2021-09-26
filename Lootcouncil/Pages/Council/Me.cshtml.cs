using Lootcouncil.Extensions;
using Lootcouncil.Models;
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

        [BindProperty]
        public int Id { get; set; }
        public JournalInstanceResponse Instance { get; set; }
        public List<JournalEncounterResponse> Encounters { get; set; }

        public MeModel(ILogger<MeModel> logger, IDbRepository db, IApiRepository api)
        {
            _logger = logger;
            _db = db;
            _api = api;
        }

        public async Task OnGetAsync(int Id)
        {
            var region = Request.Cookies.GetRegion();
            var council = await _db.GetCouncil(Id);

            Instance = await _api.GetJournalInstanceResponse(council.InstanceId, region);
            Encounters = new List<JournalEncounterResponse>();
            foreach(var encounter in Instance.Encounters)
            {
                Encounters.Add(await _api.GetJournalEncounterResponse(encounter.Id, region));
            }
        }

        public async Task<IActionResult> OnPostAsync(int Id, [FromBody]Dictionary<int, int> votes)
        {
            return RedirectToPage("/Council/Me", new { Id });
        }
    }
}
