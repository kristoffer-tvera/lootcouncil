using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lootcouncil.Models.Db
{
    public class CouncilMember
    {
        public int CouncilId { get; set; }
        public string Name { get; set; }
        public string Realm { get; set; }
    }
}
