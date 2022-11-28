using Treaning.WebAPI.Exceptions;
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
        private readonly IFileService _fileService;
        public AccountService(IStudentRepository studentRepository, IFileService fileService)
        {
            this._studentRepository = studentRepository;
            this._fileService = fileService;
        }
        public async Task<bool> RegistrAsync(StudentCreateViewModel studentCreateViewModel)
        {
            var student = (Student)studentCreateViewModel;
            var hasherResult = PasswordHasher.Hash(studentCreateViewModel.Password!);
            student.PasswordHash = hasherResult.Hash;
            student.Salt = hasherResult.Salt;
            student.ImagePath = await _fileService.SaveImageAsync(studentCreateViewModel.Image);
            await _studentRepository.CreateAsync(student);
            return true;
        }
    }
}
