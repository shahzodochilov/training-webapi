using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Enums;
using Treaning.WebAPI.Models;

namespace Treaning.WebAPI.ViewModels.Students
{
    public class StudentViewModel
    {
        public long Id { get; set; }

        public string? Firstname { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public string? ImageUrl { get; set; }

        public static implicit operator StudentViewModel(Student student)
        {
            return new StudentViewModel()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                Gender = student.Gender == Enums.Gender.Male ? "Male" : "Female",
                ImageUrl = student.ImagePath
            };
        }
    }
}
