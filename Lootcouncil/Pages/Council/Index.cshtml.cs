using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Pages.Council
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDbRepository _db;
        public Models.Db.Council CurrentCouncil { get; set; }
        public IEnumerable<Models.Db.Council> Councils { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDbRepository db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task OnGetAsync(int id = -1)
        {
            if(id > 0)
            {
                CurrentCouncil = await _db.GetCouncil(id);
            } else
            {
                var character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));
                Councils = await _db.GetCouncilsForCharacter(character.Id);
            }
        }
    }
}
