using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Treaning.WebAPI.Exceptions;
using Treaning.WebAPI.Interfaces.Services;
using Treaning.WebAPI.Models;
using Treaning.WebAPI.Utils;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Controllers
{
    [Route("api/students")]
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
           => Ok(await _studentService.GetAllAsync(@params));

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _studentService.GetAsync(id);
            if (result.Id == 0) throw new StatusCodeException(HttpStatusCode.NotFound, "Student not found");
            else return Ok(result);
        }

        [HttpGet("{id}/treanings"), AllowAnonymous]
        public async Task<IActionResult> GetAllTreaningsAsync(long id)
        {
            return Ok();
        }


        [HttpPut("{id}"), AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] StudentUpdateViewModel studentUpdateViewModel)
            => Ok(await _studentService.UpdateAsync(id, studentUpdateViewModel));
        //{
        //    var result =;
        //    if (result) throw new StatusCodeException(HttpStatusCode.OK, "Successfully");
        //    else throw new StatusCodeException(HttpStatusCode.NotFound, "Student not found");
        //}

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await _studentService.DeleteAsync(id));
    }
}
