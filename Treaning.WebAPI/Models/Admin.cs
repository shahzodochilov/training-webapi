using Treaning.WebAPI.Enums;

namespace Treaning.WebAPI.Models
{
    public class Admin : Pupil
    {
        public Role Role { get; } = Role.Admin;
    }
}
