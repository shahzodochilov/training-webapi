using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Interfaces.Services
{
    public interface IAccountService
    {
        Task<(int statusCode, string message)> RegistrAsync(StudentCreateViewModel studentCreateViewModel);
    }
}
