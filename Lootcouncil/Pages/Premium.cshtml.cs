using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages
{
    public class PremiumModel : PageModel
    {
        private ILogger<PremiumModel> _logger;

        public PremiumModel(ILogger<PremiumModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
