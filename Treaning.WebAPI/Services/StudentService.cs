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

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync(PaginationParams @params)
        {
            var students = (await _studentRepository.GetAllAsync()).Skip(@params.GetSkipCount()).Take(@params.PageSize);
            var studentViewModels = new List<StudentViewModel>();
            foreach (var student in students)
            {
                var studentViewModel = (StudentViewModel)student;
                studentViewModels.Add(studentViewModel);
            }
            return studentViewModels;
        }

        public async Task<(int statusCode, StudentViewModel studentViewModel, string message)> GetAsync(long id)
        {
            var student = await _studentRepository.FindeAsync(id);
            StudentViewModel studentViewModel = new StudentViewModel();
            if (student is not null)
            {
                studentViewModel = (StudentViewModel)student;
                return (statusCode: 200, studentViewModel, message: "");
            }
            else return (statusCode: 404, studentViewModel = new StudentViewModel(), message: "Student not found");
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
