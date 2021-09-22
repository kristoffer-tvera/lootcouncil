using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Lootcouncil.Pages.Council
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDbRepository _db;
        public Models.Council CurrentCouncil { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDbRepository db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGetAsync(int id = -1)
        {
            CurrentCouncil = await _db.GetCouncil(id);
        }
    }
}
