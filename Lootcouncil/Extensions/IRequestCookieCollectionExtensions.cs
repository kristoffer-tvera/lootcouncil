using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Lootcouncil.Extensions
{
    public static class IRequestCookieCollectionExtensions
    {
        public static string GetRegion(this IRequestCookieCollection cookieCollection)
        {
            var region = cookieCollection["region"];
            if (string.IsNullOrWhiteSpace(region))
            {
                region = Constants.Regions.First();
            }

            return region;
        }
    }
}
