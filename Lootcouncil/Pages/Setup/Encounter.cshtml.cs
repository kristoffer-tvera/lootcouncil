using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Setup
{
    public class EncounterModel : PageModel
    {
        private readonly ILogger<EncounterModel> _logger;
        private readonly IApiRepository _api;
        public JournalEncounterResponse Encounter { get; set; }

        public EncounterModel(ILogger<EncounterModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync(int id)
        {
            await _api.Setup();
            Encounter = await _api.GetJournalEncounterResponse(id);
        }
    }
}
