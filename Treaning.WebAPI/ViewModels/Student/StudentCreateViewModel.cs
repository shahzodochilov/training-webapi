using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Enums;

namespace Treaning.WebAPI.ViewModels.Student
{
    public class StudentCreateViewModel
    {
        [Required, MaxLength(50)]
        public string? Firstname { get; set; }

        [Required, MaxLength(50)]
        public string? LastName { get; set; }

        [Required, StringLength(13)]
        public string? PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
