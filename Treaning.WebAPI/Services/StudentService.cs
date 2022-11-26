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

        public async Task<IEnumerable<Student>> GetAllAsync(PaginationParams @params)
        {
            var students = (await _studentRepository.GetAllAsync()).Skip(@params.GetSkipCount()).Take(@params.PageSize);
            return students;
        }

        public async Task<(int statusCode, Student student, string message)> GetAsync(long id)
        {
            var student = await _studentRepository.FindeAsync(id);
            if (student is not null) return (statusCode: 200, student, message: "");
            else return (statusCode: 404, student = new Student(), message: "Student not found");
        }

        public async Task<(int statusCode, string message)> UpdateAsync(long id, StudentUpdateViewModel studentUpdateViewModel)
        {
            var student = await _studentRepository.FindeAsync(id);
            if (student is not null)
            {
                Student updateStudent = new Student();
                updateStudent = (Student)studentUpdateViewModel;
                updateStudent.PasswordHash = student.PasswordHash;
                await _studentRepository.UpdateAsync(id, updateStudent);
                return (statusCode: 200, message: "");
            }
            else return (statusCode: 404, message: "Student not found");
        }
    }
}
