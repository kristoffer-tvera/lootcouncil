using Lootcouncil.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public interface IDbRepository
    {
        Task<IEnumerable<Council>> GetCouncilsForGuild(int guildId);
        Task<IEnumerable<Council>> GetCouncilsForCharacter(int characterId);
        Task<Council> GetCouncil(int id);
    }
}