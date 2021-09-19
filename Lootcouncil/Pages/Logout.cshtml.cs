using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Lootcouncil.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly ILogger<LogoutModel> _logger;
        private readonly IConfiguration _config;
        public LogoutModel(ILogger<LogoutModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult OnGet()
        {
            SignOut("cookie", "oidc");
            //var host = _settings.Authority;
            var cookieName = _config["Cookie"];

            //var clientId = _settings.ClientId;
            //var url = host + "/oauth2/logout?client_id=" + clientId;
            Response.Cookies.Delete(cookieName);
            return Redirect("/");
        }
    }
}
