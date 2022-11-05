using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Enums;

namespace Treaning.WebAPI.Models
{
    public class Pupil
    {
        public long Id { get; set; }

        [MaxLength(50)]
        public string? Firstnam { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [StringLength(13)]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public Gender Gender { get; set; }
    }
}
