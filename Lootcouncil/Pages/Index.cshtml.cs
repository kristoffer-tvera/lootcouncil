using Lootcouncil.Extensions;
using Lootcouncil.Models.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public bool IsLoggedIn { get; set; }
        public string CharacterName { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            IsLoggedIn = User.Identity.IsAuthenticated;
            var character = HttpContext.Session.Get<Character>(nameof(Character));
            if(character != null)
            {
                CharacterName = character.Name;
            }
        }
    }
}
