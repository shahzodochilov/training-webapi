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

        public async Task<bool> DeleteAsync(long id)
        {
            var student = await _studentRepository.FindeAsync(id);
            if(student is not null)
            {
                await _studentRepository.DeleteAsync(id);
                return true;
            }
            return false;
            
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

        public async Task<StudentViewModel> GetAsync(long id)
        {
            var student = await _studentRepository.FindeAsync(id);
            StudentViewModel studentViewModel = new StudentViewModel();
            if (student is not null)
            {
                studentViewModel = (StudentViewModel)student;
                return studentViewModel;
            }
            else return new StudentViewModel();
        }

        public async Task<bool> UpdateAsync(long id, StudentUpdateViewModel studentUpdateViewModel)
        {
            var student = await _studentRepository.FindeAsync(id);
            if (student is not null)
            {
                Student updateStudent = new Student();
                updateStudent = (Student)studentUpdateViewModel;
                updateStudent.PasswordHash = student.PasswordHash;
                await _studentRepository.UpdateAsync(id, updateStudent);
                return true;
            }
            else return false;
        }
    }
}
