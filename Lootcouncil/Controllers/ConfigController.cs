using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lootcouncil.Controllers
{
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        [Route("[action]")]
        public async Task<IActionResult> SetRegion(string region, string returnUrl)
        {
            Response.Cookies.Append("region", region);
            return Redirect(returnUrl);
        }

    }
}
