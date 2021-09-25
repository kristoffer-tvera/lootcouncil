using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lootcouncil.Models.Db
{
    public class Council
    {
        public int Id { get; set; }
        public int GuildId { get; set; }
        public int InstanceId { get; set; }
    }
}
