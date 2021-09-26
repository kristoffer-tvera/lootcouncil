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

        public async Task<IEnumerable<Council>> GetCouncilsForCharacter(string name, string realm)
        {
            var councilMemberships = GetCouncilMembers().Where(cm => cm.Name == name && cm.Realm == realm);
            var councils = GetCouncils().Where(c => councilMemberships.Any(cm => cm.CouncilId == c.Id));



            return await Task.FromResult(councils);
        }

        public async Task<Council> GetCouncil(int id)
        {
            var councils = GetCouncils().First(c => c.Id == id);

            return await Task.FromResult(councils);
        }

        public async Task<Council> CreateNewCouncil(int guildId, int instanceId)
        {
            var councils = GetCouncils().First();

            return await Task.FromResult(councils);
        }


        public async Task AddCouncilMembers(IEnumerable<CouncilMember> members)
        {
            return;
        }

        public async Task RemoveCouncilMember(CouncilMember member)
        {
            return;
        }

        public async Task<IEnumerable<CouncilMember>> GetCouncilMembers(int councilId)
        {
            var members = GetCouncilMembers();
            return members.Where(m => m.CouncilId == councilId);
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
                new CouncilMember { CouncilId = 1, Name = "Bsl", Realm = "stormscale"},
                new CouncilMember { CouncilId = 1, Name = "Yukela", Realm = "stormscale"},
                new CouncilMember { CouncilId = 2, Name = "Bsl", Realm = "stormscale"},
                new CouncilMember { CouncilId = 2, Name = "Jsj", Realm = "stormscale"},
                new CouncilMember { CouncilId = 2, Name = "Ibb", Realm = "stormscale"}
            };

            return members;
        }

        
    }
}
