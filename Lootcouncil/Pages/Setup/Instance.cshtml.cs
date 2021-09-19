using System.Threading.Tasks;
using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Setup
{
    public class InstanceModel : PageModel
    {
        private readonly ILogger<InstanceModel> _logger;
        private readonly IApiRepository _api;
        public JournalExpansionResponse Instances { get; set; }

        public InstanceModel(ILogger<InstanceModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync(int id)
        {
            await _api.Setup();
            Instances = await _api.GetJournalExpansionResponse(id);
        }
    }
}
