using Dapper.Contrib.Extensions;

namespace Lootcouncil.Models.Db
{
    [Table("Council")]
    public class Council
    {
        [Key]
        public int Id { get; set; }
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public string GuildRealm { get; set; }
        public int InstanceId { get; set; }

        [Write(false)]
        [Computed]
        public JournalInstanceResponse Instance { get; set; }
    }
}
