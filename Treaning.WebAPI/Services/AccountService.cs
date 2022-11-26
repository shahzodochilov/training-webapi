using Treaning.WebAPI.Interfaces.Repositories;
using Treaning.WebAPI.Interfaces.Services;
using Treaning.WebAPI.Models;
using Treaning.WebAPI.Security;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IStudentRepository _studentRepository;
        public AccountService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        public async Task<(int statusCode, string message)> RegistrAsync(StudentCreateViewModel studentCreateViewModel)
        {
            var student = (Student)studentCreateViewModel;
            var hasherResult = PasswordHasher.Hash(studentCreateViewModel.Password!);
            student.PasswordHash = hasherResult.Hash;
            student.Salt = hasherResult.Salt;
            await _studentRepository.CreateAsync(student);
            return (statusCode: 200, message: "Saved successfully");
        }
    }
}
