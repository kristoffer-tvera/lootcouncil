using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lootcouncil.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetBattleTag(this ClaimsPrincipal principal)
        {
            return principal?.FindFirst(x => x.Type.Equals("battle_tag"))?.Value;
        }
    }
}
