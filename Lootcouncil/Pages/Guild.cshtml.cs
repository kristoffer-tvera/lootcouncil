using Lootcouncil.Extensions;
using Lootcouncil.Models;
using Lootcouncil.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Pages
{
    public class GuildModel : PageModel
    {
        private ILogger<GuildModel> _logger;
        private readonly IMemoryCache _cache;
        private readonly IApiRepository _api;
        private readonly IDbRepository _db;

        public GuildRosterResponse Guild { get; set; }
        public GuildActivitiesResponse GuildActivities { get; set; }
        public IEnumerable<Models.Db.Council> Councils { get; set; }

        public GuildModel(ILogger<GuildModel> logger, IMemoryCache cache, IApiRepository api, IDbRepository db)
        {
            _logger = logger;
            _cache = cache;
            _api = api;
            _db = db;
        }

        public async Task OnGetAsync()
        {
            var region = Request.Cookies.GetRegion();
            var character = HttpContext.Session.Get<CharacterResponse>(nameof(CharacterResponse));
            var guild = await _api.GetGuildResponse(character.Guild.Key.Href, region);

            Guild = await _api.GetGuildRosterResponse(guild.Roster.Href, region);
            GuildActivities = await _api.GetGuildActivitiesResponse(guild.Activity.Href, region);
            Councils = await _db.GetCouncilsForGuild(guild.Id);

            foreach (var council in Councils)
            {
                council.Instance = await _api.GetJournalInstanceResponse(council.InstanceId, region);
            }
        }
    }
}
