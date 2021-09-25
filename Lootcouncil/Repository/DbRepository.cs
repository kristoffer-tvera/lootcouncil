using Lootcouncil.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public class DbRepository : IDbRepository
    {
        public async Task<IEnumerable<Council>> GetCouncilsForGuild(int guildId)
        {
            var councils = GetCouncils();

            return await Task.FromResult(councils);
        }

        public async Task<IEnumerable<Council>> GetCouncilsForCharacter(int characterId)
        {
            var councilMemberships = GetCouncilMembers().Where(cm => cm.CharacterID == characterId);
            var councils = GetCouncils().Where(c => councilMemberships.Any(cm => cm.CouncilId == c.Id));



            return await Task.FromResult(councils);
        }

        public async Task<Council> GetCouncil(int id)
        {
            var councils = GetCouncils().First(c => c.Id == id);

            return await Task.FromResult(councils);
        }

        private IEnumerable<Council> GetCouncils()
        {
            var councils = new List<Council>() {
                new Council { Id = 1, GuildId = 1, InstanceId = 1193},
                new Council { Id = 2, GuildId = 1, InstanceId = 1190},
                new Council { Id = 3, GuildId = 2, InstanceId = 1193}
            };

            return councils;
        }

        private IEnumerable<CouncilMember> GetCouncilMembers()
        {
            var members = new List<CouncilMember>() {
                new CouncilMember { CouncilId = 1, CharacterID = 157481447},
                new CouncilMember { CouncilId = 2, CharacterID = 157481447},
                new CouncilMember { CouncilId = 2, CharacterID = 1},
                new CouncilMember { CouncilId = 2, CharacterID = 2}
            };

            return members;
        }
    }
}
