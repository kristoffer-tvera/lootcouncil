using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Council
{
    public class MeModel : PageModel
    {
        private readonly ILogger<MeModel> _logger;
        public int Id { get; set; }

        public MeModel(ILogger<MeModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int id)
        {
            Id = id;
        }
    }
}
