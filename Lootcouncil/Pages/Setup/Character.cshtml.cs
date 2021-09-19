using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lootcouncil.Extensions;
using Lootcouncil.Models.Shared;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lootcouncil.Pages.Setup
{
    public class CharacterModel : PageModel
    {
        private readonly ILogger<CharacterModel> _logger;
        private readonly IApiRepository _api;

        public IEnumerable<EquippedItem> EquippedItems { get; set; }
        public int CharacterId { get; set; }


        public CharacterModel(ILogger<CharacterModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync(string realm, string name)
        {
            var equipment = await _api.GetCharacterEquipmentResponse(realm, name.ToLower(), "eu");
            EquippedItems = equipment.EquippedItems;
            CharacterId = equipment.Character.Id;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var profile = await _api.GetProfileSummary("eu", accessToken);

            Character character = null;
            foreach (var account in profile.WowAccounts)
            {
                character = account.Characters.FirstOrDefault(c => c.Id == id);
                if(character != null)
                {
                    break;
                }
            }

            HttpContext.Session.Set(nameof(Character), character);

            return Redirect("/");
        }
    }
}
