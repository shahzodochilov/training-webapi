using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Attributes;
using Treaning.WebAPI.Enums;
using Treaning.WebAPI.Models;

namespace Treaning.WebAPI.ViewModels.Students
{
    public class StudentUpdateViewModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
            ErrorMessage = "Please enter valid first name. " +
            "First name must be contains only letters or ' character")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(50), MinLength(2)]
        [RegularExpression(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$",
                ErrorMessage = "Please enter valid last name. " +
                "Last name must be contains only letters or ' character")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$",
                ErrorMessage = "Please enter valid phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                ErrorMessage = "Please enter valid email")]
        public string? Email { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public static implicit operator Student(StudentUpdateViewModel studentUpdateViewModel)
        {
            return new Student()
            {
                Firstname = studentUpdateViewModel.Firstname,
                LastName = studentUpdateViewModel.LastName,
                PhoneNumber = studentUpdateViewModel.PhoneNumber,
                Email = studentUpdateViewModel.Email,
                Gender = studentUpdateViewModel.Gender
            };
        }
    }
}
