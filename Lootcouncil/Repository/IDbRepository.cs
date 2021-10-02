using Lootcouncil.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public interface IDbRepository
    {
        Task<IEnumerable<Council>> GetCouncilsForGuild(int guildId);
        Task<IEnumerable<Council>> GetCouncilsForCharacter(string name, string realm);
        Task<Council> CreateNewCouncil(int guildId, string guildName, string guildRealm, int instanceId);
        Task<IEnumerable<CouncilMember>> GetCouncilMembers(int councilId);
        Task AddCouncilMembers(IEnumerable<CouncilMember> members);
        Task RemoveCouncilMember(CouncilMember member);
        Task<Council> GetCouncil(int id);

        Task<IEnumerable<Entry>> GetEntries(int councilId);
        Task<IEnumerable<Entry>> GetEntriesForItemByCharacter(int councilId, int itemId, string name, string realm);
        Task<IEnumerable<Entry>> GetEntriesForCharacter(int councilId, string name, string realm);
        Task<IEnumerable<Entry>> GetEntriesForEncounter(int councilId, int encounterId);
        Task SaveEntries(IEnumerable<Entry> entries);

    }
}