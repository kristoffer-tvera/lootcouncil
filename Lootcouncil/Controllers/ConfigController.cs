using Microsoft.AspNetCore.Mvc;

namespace Lootcouncil.Controllers
{
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        [Route("[action]")]
        public IActionResult SetRegion(string region, string returnUrl)
        {
            Response.Cookies.Append("region", region);
            return Redirect(returnUrl);
        }

    }
}
