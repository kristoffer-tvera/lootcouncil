using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Auth
{
    public class SigninModel : PageModel
    {
        private ILogger<SigninModel> _logger;

        public SigninModel(ILogger<SigninModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Redirect("/");
        }
    }
}
