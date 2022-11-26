using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Attributes;
using Treaning.WebAPI.Enums;

namespace Treaning.WebAPI.ViewModels.Students
{
    public class StudentLoginViewModel
    {
        [EmailAddress]
        public string? Email { get; set; }

        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}
