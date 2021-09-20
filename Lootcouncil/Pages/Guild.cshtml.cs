using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages
{
    public class GuildModel : PageModel
    {
        private ILogger<GuildModel> _logger;

        public GuildModel(ILogger<GuildModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
