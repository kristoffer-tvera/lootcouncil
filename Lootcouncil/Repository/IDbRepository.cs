using Lootcouncil.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public interface IDbRepository
    {
        Task<IEnumerable<Council>> GetCouncilsForGuild(int guildId);
        Task<Council> GetCouncil(int id);
    }
}