using Lootcouncil.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public interface IDbRepository
    {
        Task<IEnumerable<Council>> GetCouncilsForGuild(int guildId);
        Task<IEnumerable<Council>> GetCouncilsForCharacter(string name, string realm);
        Task<Council> CreateNewCouncil(int guildId, int instanceId);
        Task<IEnumerable<CouncilMember>> GetCouncilMembers(int councilId);
        Task AddCouncilMembers(IEnumerable<CouncilMember> members);
        Task RemoveCouncilMember(CouncilMember member);
        Task<Council> GetCouncil(int id);
    }
}