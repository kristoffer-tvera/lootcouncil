namespace Lootcouncil.Models
{
    public class BlizzardSettings
    {
        public const string Section = "Blizzard";
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Locale { get; set; }
        public string Region { get; set; }
        public string Redirect { get; set; }
    }
}
