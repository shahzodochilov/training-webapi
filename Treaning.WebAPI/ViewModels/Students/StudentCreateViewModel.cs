using System.ComponentModel.DataAnnotations;
using Treaning.WebAPI.Enums;
using Treaning.WebAPI.Models;

namespace Treaning.WebAPI.ViewModels.Students;

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

    public static implicit operator Student(StudentCreateViewModel studentCreateViewModel)
    {
        return new Student()
        {
            Firstname = studentCreateViewModel.Firstname,
            LastName = studentCreateViewModel.LastName,
            PhoneNumber = studentCreateViewModel.PhoneNumber,
            Email = studentCreateViewModel.Email,
            Gender = studentCreateViewModel.Gender,

        };
    }
}
