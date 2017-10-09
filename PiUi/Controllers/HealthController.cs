using Microsoft.AspNetCore.Mvc;

namespace PiUi.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}