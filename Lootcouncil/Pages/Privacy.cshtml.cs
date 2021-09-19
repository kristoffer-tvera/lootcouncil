using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Lootcouncil.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IApiRepository _api;

        public string Test { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync()
        {
            await _api.Setup();
            var debug = await _api.GetJournalExpansionIndexResponse();
        }
    }
}
