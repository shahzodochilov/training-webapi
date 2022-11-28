using Microsoft.AspNetCore.Mvc;
using Treaning.WebAPI.Models;
using Treaning.WebAPI.Utils;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllAsync(PaginationParams @params);

        Task<StudentViewModel> GetAsync(long id);

        Task<bool> UpdateAsync(long id, StudentUpdateViewModel studentUpdateViewModel);

        Task<bool> DeleteAsync(long id);
    }
}
