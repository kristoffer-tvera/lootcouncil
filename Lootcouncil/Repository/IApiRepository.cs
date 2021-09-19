using Lootcouncil.Models;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public interface IApiRepository
    {
        Task<CharacterEquipmentResponse> GetCharacterEquipmentResponse(string realm, string name, string region);
        Task<GuildActivitiesResponse> GetGuildActivitiesResponse(string realm, string name, string region);
        Task<GuildResponse> GetGuildResponse(string realm, string name, string region);
        Task<GuildRosterResponse> GetGuildRosterResponse(string realm, string name, string region);
        Task<ItemResponse> GetItemResponse(int id);
        Task<JournalEncounterResponse> GetJournalEncounterResponse(int id);
        Task<JournalExpansionIndexResponse> GetJournalExpansionIndexResponse();
        Task<JournalExpansionResponse> GetJournalExpansionResponse(int id);
        Task<JournalInstanceResponse> GetJournalInstanceResponse(int id);
        Task<ProfileSummaryResponse> GetProfileSummary(string region, string accessToken);
        Task<string> GetAccessTokenFromAuthorizationCode(string code);
        Task Setup();
    }
}