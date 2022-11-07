using Microsoft.AspNetCore.Mvc;
using Treaning.WebAPI.Interfaces.Repositories;
using Treaning.WebAPI.Interfaces.Services;
using Treaning.WebAPI.Models;
using Treaning.WebAPI.Utils;
using Treaning.WebAPI.ViewModels.Students;

namespace Treaning.WebAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public async Task<(int statusCode, string message)> CreateAsync(StudentCreateViewModel studentCreateViewModel)
        {
            var student = (Student) studentCreateViewModel;
            await _studentRepository.CreateAsync(student);
            return (statusCode: 200, message: "");
        }

        public async Task<(int statusCode, string message)> DeleteAsync(long id)
        {
            var student = await _studentRepository.FindeAsync(id);
            if(student is not null)
            {
                await _studentRepository.DeleteAsync(id);
                return (statusCode: 200, message: "");
            }
            return (statusCode: 404, message: "Student not found");
            
        }

        public Task<(int statusCode, string message)> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<(int statusCode, string message)> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<(int statusCode, string message)> UpdateAsync(long id, StudentCreateViewModel studentUpdateViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
