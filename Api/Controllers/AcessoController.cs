using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("v1")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return new OkResult();//View();
        }
    }
}