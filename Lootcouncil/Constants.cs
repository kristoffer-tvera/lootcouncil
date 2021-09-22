using System.Collections.Generic;

namespace Lootcouncil
{
    public static class Constants
    {
        public static IEnumerable<string> Regions = new List<string>() { "EU", "US", "KR", "TW" };
        public static IEnumerable<string> Locales = new List<string>() { "en_GB", "en_US", "ko_KR", "zh_TW" };

        public static string CookieCharacter = "Character";
        public static string CookieRealm = "Realm";
        public static string CookieRegion = "Region";

        /// <summary>
        /// 10 days
        /// </summary>
        public static int CachePolicyHardcore = 10 * 24 * 60 * 60;

        /// <summary>
        /// One day
        /// </summary>
        public static int CachePolicyAggresive = 1 * 24 * 60 * 60;

        /// <summary>
        /// 6 hours
        /// </summary>
        public static int CachePolicyMedium = 6 * 60 * 60;

        /// <summary>
        /// One hour
        /// </summary>
        public static int CachePolicyLight = 1 * 60 * 60;

        /// <summary>
        /// 15 minutes
        /// </summary>
        public static int CachePolicyLax = 15 * 60;

        /// <summary>
        /// One minute
        /// </summary>
        public static int CachePolicyUltraLax = 60;
    }
}
