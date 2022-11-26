using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Attributes;
using Treaning.WebAPI.Enums;

namespace Treaning.WebAPI.ViewModels.Students
{
    public class StudentLoginViewModel
    {
        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, PasswordPropertyText]
        public string? Password { get; set; }
    }
}
