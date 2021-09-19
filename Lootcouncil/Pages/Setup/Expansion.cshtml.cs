using System.Threading.Tasks;
using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Setup
{
    public class ExpansionModel : PageModel
    {
        private readonly ILogger<ExpansionModel> _logger;
        private readonly IApiRepository _api;

        public JournalExpansionIndexResponse Expansions { get; set; }

        public ExpansionModel(ILogger<ExpansionModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {
            Expansions = await _api.GetJournalExpansionIndexResponse(HttpContext.Request.Cookies.GetRegion());
        }
    }
}
