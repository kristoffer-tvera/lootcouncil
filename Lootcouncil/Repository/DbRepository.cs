using Dapper;
using Dapper.Contrib.Extensions;
using Lootcouncil.Models.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lootcouncil.Repository
{
    public class DbRepository : IDbRepository
    {
        private readonly ILogger<DbRepository> _logger;
        private readonly MySqlConnection _connection;

        public DbRepository(IConfiguration config, ILogger<DbRepository> logger)
        {
            var connectionString = config.GetConnectionString("Db");
            _connection = new MySqlConnection(connectionString);
            _logger = logger;
        }

        public async Task<IEnumerable<Council>> GetCouncilsForGuild(int guildId)
        {
            try
            {
                var councils = await _connection.QueryAsync<Council>("SELECT * FROM Council WHERE GuildId = @guildId", new { guildId });
                return councils;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<Council>();
        }

        public async Task<IEnumerable<Council>> GetCouncilsForCharacter(string name, string realm)
        {
            try
            {
                var councils = await _connection.QueryAsync<Council>("SELECT * FROM CouncilMember LEFT JOIN Council ON Council.Id = CouncilMember.CouncilId WHERE CouncilMember.Name = @name AND CouncilMember.Realm = @realm ", new { name, realm });
                return councils;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<Council>();
        }

        public async Task<Council> GetCouncil(int id)
        {
            try
            {
                var councils = await _connection.GetAsync<Council>(id);
                return councils;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return null;
        }

        public async Task<Council> CreateNewCouncil(int guildId, string guildName, string guildRealm, int instanceId)
        {
            var council = new Council
            {
                GuildId = guildId,
                GuildName = guildName,
                GuildRealm = guildRealm,
                InstanceId = instanceId
            };

            await _connection.InsertAsync(council);

            return council;
        }


        public async Task AddCouncilMembers(IEnumerable<CouncilMember> members)
        {
            await _connection.InsertAsync(members);
        }

        public async Task RemoveCouncilMember(CouncilMember member)
        {
            await _connection.DeleteAsync(member);
        }

        public async Task<IEnumerable<CouncilMember>> GetCouncilMembers(int councilId)
        {
            try
            {
                var members = await _connection.QueryAsync<CouncilMember>("SELECT * FROM CouncilMember WHERE CouncilId = @councilId ", new { councilId });
                return members;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<CouncilMember>();
        }

        public async Task<IEnumerable<Entry>> GetEntries(int councilId)
        {
            try
            {
                var entries = await _connection.QueryAsync<Entry>("SELECT * FROM Entry WHERE CouncilId = @councilId ", new { councilId });
                return entries;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<Entry>();
        }

        public async Task<IEnumerable<Entry>> GetEntriesForItemByCharacter(int councilId, int itemId, string name, string realm)
        {
            try
            {
                var entries = await _connection.QueryAsync<Entry>("SELECT * FROM Entry WHERE CouncilId = @councilId AND ItemId = @itemId AND Name = @name AND Realm = @realm", new { councilId, itemId, name, realm });
                return entries;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<Entry>();
        }

        public async Task<IEnumerable<Entry>> GetEntriesForCharacter(int councilId, string name, string realm)
        {
            try
            {
                var entries = await _connection.QueryAsync<Entry>("SELECT * FROM Entry WHERE CouncilId = @councilId AND Name = @name AND Realm = @realm", new { councilId, name, realm });
                return entries;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<Entry>();
        }

        public async Task<IEnumerable<Entry>> GetEntriesForItem(int councilId, int itemId)
        {
            try
            {
                var entries = await _connection.QueryAsync<Entry>("SELECT * FROM Entry WHERE CouncilId = @councilId AND ItemId = @itemId", new { councilId, itemId });
                return entries;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<Entry>();
        }

        public async Task<IEnumerable<Entry>> GetEntriesForEncounter(int councilId, int encounterId)
        {
            try
            {
                var entries = await _connection.QueryAsync<Entry>("SELECT * FROM Entry WHERE CouncilId = @councilId AND EncounterId = @encounterId", new { councilId, encounterId });
                return entries;
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message);
            }

            return Enumerable.Empty<Entry>();
        }

        public async Task SaveEntries(IEnumerable<Entry> entries)
        {
            await _connection.InsertAsync(entries);
        }
    }
}
