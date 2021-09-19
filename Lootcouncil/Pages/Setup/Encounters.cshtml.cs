using System.Threading.Tasks;
using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Setup
{
    public class EncountersModel : PageModel
    {
        private readonly ILogger<EncountersModel> _logger;
        private readonly IApiRepository _api;
        public JournalInstanceResponse Instance { get; set; }

        public EncountersModel(ILogger<EncountersModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync(int id)
        {
            await _api.Setup();
            Instance = await _api.GetJournalInstanceResponse(id);
        }
    }
}
