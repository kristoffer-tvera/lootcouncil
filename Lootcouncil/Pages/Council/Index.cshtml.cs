using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Council
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public int Id { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int id = -1)
        {
            Id = id;
        }
    }
}
