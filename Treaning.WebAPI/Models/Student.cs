using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Enums;

namespace Treaning.WebAPI.Models
{
    public class Student : Pupil
    {
        public string? PasswordHash { get; set; }

        public string? Salt { get; set; }

        public Role Role { get; } = Role.User;
    }
}
