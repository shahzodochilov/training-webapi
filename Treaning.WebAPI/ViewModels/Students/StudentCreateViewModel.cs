using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Atributes;
using Treaning.WebAPI.Attributes;
using Treaning.WebAPI.Enums;
using Treaning.WebAPI.Models;

namespace Treaning.WebAPI.ViewModels.Students;

public class StudentCreateViewModel
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

        [Required(ErrorMessage = "Image is required")]
        [DataType(DataType.Upload)]
        [MaxFileSize(3)]
        [AllowedFileExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile Image { get; set; } = null!;

        [Required]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StrongPassword]
        public string? Password { get; set; }

        public static implicit operator Student(StudentCreateViewModel studentCreateViewModel)
        {
            return new Student()
            {
                Firstname = studentCreateViewModel.Firstname,
                LastName = studentCreateViewModel.LastName,
                PhoneNumber = studentCreateViewModel.PhoneNumber,
                Email = studentCreateViewModel.Email,
                Gender = studentCreateViewModel.Gender,
                PasswordHash = studentCreateViewModel.Password,
            };
        }
}
