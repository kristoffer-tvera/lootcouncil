using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Models.Db;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lootcouncil.Pages.Council
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDbRepository _db;
        private readonly IApiRepository _api;

        public Models.Db.Council CurrentCouncil { get; set; }
        public CharacterResponse Character { get; set; }
        public IEnumerable<Models.Db.Council> Councils { get; set; }
        public IEnumerable<Models.Db.CouncilMember> CouncilMembers { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
        public JournalInstanceResponse Instance { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IDbRepository db, IApiRepository api)
        {
            _logger = logger;
            _db = db;
            _api = api;
        }

        public async Task OnGetAsync(int id = -1)
        {
            var region = Request.Cookies.GetRegion();
            Character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));

            if (id > 0)
            {

                CurrentCouncil = await _db.GetCouncil(id);
                Instance = await _api.GetJournalInstanceResponse(CurrentCouncil.InstanceId, region);
                CouncilMembers = await _db.GetCouncilMembers(CurrentCouncil.Id);

                if(!CouncilMembers.Any(member => member.Name == Character.Name && member.Realm == Character.Realm.Slug)){
                    // Attempted abuse
                }

                Entries = await _db.GetEntriesForCharacter(CurrentCouncil.Id, Character.Name, Character.Realm.Slug);
            } else
            {
                Councils = await _db.GetCouncilsForCharacter(Character.Name, Character.Realm.Slug);

                foreach(var council in Councils)
                {
                    council.Instance = await _api.GetJournalInstanceResponse(council.InstanceId, region);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(int councilId, string character, string realm)
        {
            var councilMember = new CouncilMember
            {
                CouncilId = councilId,
                Name = character,
                Realm = realm
            };
            await _db.RemoveCouncilMember(councilMember);

            return RedirectToPage("/Council/Index", new { id = councilId });
        }
    }
}
