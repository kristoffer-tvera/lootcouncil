using Dapper.Contrib.Extensions;

namespace Lootcouncil.Models.Db
{
    [Table("Entry")]
    public class Entry
    {
        [ExplicitKey]
        public int CouncilId { get; set; }
        [ExplicitKey]
        public int ItemId { get; set; }
        public int Option { get; set; }
        public int EncounterId { get; set; }
        [ExplicitKey]
        public string Name { get; set; }
        [ExplicitKey]
        public string Realm { get; set; }
    }
}
