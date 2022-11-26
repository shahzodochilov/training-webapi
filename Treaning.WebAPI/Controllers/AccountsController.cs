using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treaning.WebAPI.Interfaces.Services;
using Treaning.WebAPI.Services;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("registr")]
        public async Task<IActionResult> CreateAsync([FromForm] StudentCreateViewModel studentCreateViewModel)
        {
            var result = await _accountService.RegistrAsync(studentCreateViewModel);
            return StatusCode(result.statusCode, result.message);
        }



        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] StudentLoginViewModel studentLoginViewModel)
        {
            return Ok();
        }

    }
}
