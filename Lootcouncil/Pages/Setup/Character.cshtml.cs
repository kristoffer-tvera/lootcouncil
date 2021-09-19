using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public CharacterModel(ILogger<CharacterModel> logger, IApiRepository api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task OnGetAsync(string realm, string name)
        {
            var character = await _api.GetCharacterEquipmentResponse(realm, name.ToLower(), "eu");
            EquippedItems = character.EquippedItems;
        }
    }
}
