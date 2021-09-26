using System.Collections.Generic;

namespace Lootcouncil
{
    public static class Constants
    {
        public static IEnumerable<string> Regions = new List<string>() { "EU", "US", "KR", "TW" };
        public static IEnumerable<string> Locales = new List<string>() { "en_GB", "en_US", "ko_KR", "zh_TW" };

        public static int LootPass = 0;
        public static int LootXmogOs = 1;
        public static int LootMinor = 2;
        public static int LootMajor = 3;
        public static int LootBis = 4;

        public enum Loot
        {
            Pass = 0,
            XmogOs = 1,
            Minor = 2,
            Major = 3,
            BiS = 4
        }

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
