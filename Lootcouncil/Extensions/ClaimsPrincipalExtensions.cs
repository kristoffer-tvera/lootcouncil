using System.Security.Claims;

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
