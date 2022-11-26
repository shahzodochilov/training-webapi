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
        private readonly IStudentService _studentService;

        public AccountsController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpPost("registr")]
        public async Task<IActionResult> CreateAsync([FromForm] StudentCreateViewModel studentCreateViewModel)
        {
            var result = await _studentService.CreateAsync(studentCreateViewModel);
            return StatusCode(result.statusCode, result.message);
        }



        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromForm] StudentLoginViewModel studentLoginViewModel)
        {
            return Ok();
        }

    }
}
