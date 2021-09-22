using Lootcouncil.Models;
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
            var councils = GetPlaceholder();

            return await Task.FromResult(councils);
        }

        public async Task<Council> GetCouncil(int id)
        {
            var councils = GetPlaceholder().First();

            return await Task.FromResult(councils);
        }

        private IEnumerable<Council> GetPlaceholder()
        {
            var councils = new List<Council>() {
                new Council { Id = 1, GuildId = 1, InstanceId = 1193},
                new Council { Id = 1, GuildId = 1, InstanceId = 1190}
            };

            return councils;
        }
    }
}
