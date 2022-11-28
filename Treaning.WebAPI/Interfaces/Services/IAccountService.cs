using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> RegistrAsync(StudentCreateViewModel studentCreateViewModel);
    }
}
