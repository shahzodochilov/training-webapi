using System.ComponentModel.DataAnnotations;

namespace Treaning.WebAPI.Models
{
    public class Student : Pupil
    {
        public string? PasswordHash { get; set; }

        public string? Salt { get; set; }
    }
}
