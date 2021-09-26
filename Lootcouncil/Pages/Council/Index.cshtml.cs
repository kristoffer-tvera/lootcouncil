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
        private readonly IApiRepository _api;

        public Models.Db.Council CurrentCouncil { get; set; }
        public IEnumerable<Models.Db.Council> Councils { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDbRepository db, IApiRepository api)
        {
            _logger = logger;
            _db = db;
            _api = api;
        }

        public async Task OnGetAsync(int id = -1)
        {
            if(id > 0)
            {
                var region = Request.Cookies.GetRegion();

                CurrentCouncil = await _db.GetCouncil(id);
                var instance = await _api.GetJournalInstanceResponse(CurrentCouncil.InstanceId, region);
                var councilMembers = await _db.GetCouncilMembers(CurrentCouncil.Id);

            } else
            {
                var character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));
                Councils = await _db.GetCouncilsForCharacter(character.Name, character.Realm.Slug);
            }
        }
    }
}
