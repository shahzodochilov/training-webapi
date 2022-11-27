using Microsoft.AspNetCore.Mvc;
using Treaning.WebAPI.Models;
using Treaning.WebAPI.Utils;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllAsync(PaginationParams @params);

        Task<(int statusCode, StudentViewModel studentViewModel, string message)> GetAsync(long id);

        Task<(int statusCode, string message)> UpdateAsync(long id, StudentUpdateViewModel studentUpdateViewModel);

        Task<(int statusCode, string message)> DeleteAsync(long id);
    }
}
