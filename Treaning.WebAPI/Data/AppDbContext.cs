using Microsoft.EntityFrameworkCore;
using Treaning.WebAPI.Models;

namespace Treaning.WebAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;

        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        public virtual DbSet<TreaningInfo> TreaningInfos { get; set; } = null!;

        public virtual DbSet<RegisterDetail> RegisterDetails { get; set; } = null!;
    }
}
