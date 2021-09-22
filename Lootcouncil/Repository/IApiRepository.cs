using Lootcouncil.Models;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public interface IApiRepository
    {
        Task<CharacterEquipmentResponse> GetCharacterEquipmentResponse(string realm, string name, string region);
        Task<CharacterResponse> GetCharacterResponse(string realm, string name, string region);
        Task<GuildActivitiesResponse> GetGuildActivitiesResponse(string realm, string name, string region);
        Task<GuildActivitiesResponse> GetGuildActivitiesResponse(string href, string region);
        Task<GuildResponse> GetGuildResponse(string realm, string name, string region);
        Task<GuildResponse> GetGuildResponse(string href, string region);
        Task<GuildRosterResponse> GetGuildRosterResponse(string realm, string name, string region);
        Task<GuildRosterResponse> GetGuildRosterResponse(string href, string region);
        Task<ItemResponse> GetItemResponse(int id, string region);
        Task<JournalEncounterResponse> GetJournalEncounterResponse(int id, string region);
        Task<JournalExpansionIndexResponse> GetJournalExpansionIndexResponse(string region);
        Task<JournalExpansionResponse> GetJournalExpansionResponse(int id, string region);
        Task<JournalInstanceResponse> GetJournalInstanceResponse(int id, string region);
        Task<ProfileSummaryResponse> GetProfileSummary(string region, string accessToken);
        Task<ItemMediaResponse> GetItemMediaResponse(string itemId, string region);
        Task Setup(string region);
    }
}