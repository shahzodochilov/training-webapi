using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treaning.WebAPI.Utils;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudensController : ControllerBase
    {
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return Ok();
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] StudentCreateViewModel studentCreateViewModel)
        {
            return Ok();
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] StudentCreateViewModel studentCreateViewModel)
        {
            return Ok();
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(0);
        }
    }
}
