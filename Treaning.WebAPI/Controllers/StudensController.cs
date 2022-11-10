using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treaning.WebAPI.Interfaces.Services;
using Treaning.WebAPI.Utils;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudensController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudensController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await _studentService.GetAllAsync(@params);
            return Ok(result);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _studentService.GetAsync(id);
            if (result.statusCode != 404) return StatusCode(result.statusCode, result.student);
            else return StatusCode(result.statusCode, result.message);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] StudentCreateViewModel studentCreateViewModel)
        {
            var result = await _studentService.CreateAsync(studentCreateViewModel);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] StudentCreateViewModel studentCreateViewModel)
        {
            var result = await _studentService.UpdateAsync(id, studentCreateViewModel);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _studentService.DeleteAsync(id);
            return StatusCode(result.statusCode, result.message);
        }
    }
}
