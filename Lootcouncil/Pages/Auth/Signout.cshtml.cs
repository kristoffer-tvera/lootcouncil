using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Auth
{
    public class SignoutModel : PageModel
    {
        private ILogger<SignoutModel> _logger;
        private IConfiguration _config;

        public SignoutModel(ILogger<SignoutModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult OnGet()
        {
            SignOut("cookie", "oidc");
            var cookieName = _config["Cookie"];

            Response.Cookies.Delete(cookieName);
            return Redirect("/");
        }
    }
}
