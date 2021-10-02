using Dapper.Contrib.Extensions;

namespace Lootcouncil.Models.Db
{
    [Table("CouncilMember")]
    public class CouncilMember
    {
        [ExplicitKey]
        public int CouncilId { get; set; }
        [ExplicitKey] 
        public string Name { get; set; }
        [ExplicitKey] 
        public string Realm { get; set; }
    }
}
