using Microsoft.AspNetCore.Mvc;
using Treaning.WebAPI.Models;
using Treaning.WebAPI.Utils;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync(PaginationParams @params);

        Task<(int statusCode, Student student, string message)> GetAsync(long id);

        Task<(int statusCode, string message)> CreateAsync(StudentCreateViewModel studentCreateViewModel);

        Task<(int statusCode, string message)> UpdateAsync(long id, StudentCreateViewModel studentUpdateViewModel);

        Task<(int statusCode, string message)> DeleteAsync(long id);
    }
}
