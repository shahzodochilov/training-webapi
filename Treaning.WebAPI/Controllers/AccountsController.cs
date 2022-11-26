using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Treaning.WebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpPost("registr")]

        public async Task<IActionResult> RegistrAsync()
        {
            return Ok();
        }
    }
}
