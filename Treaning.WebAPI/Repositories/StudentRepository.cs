using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Treaning.WebAPI.Data;
using Treaning.WebAPI.Interfaces.Repositories;
using Treaning.WebAPI.Models;

namespace Treaning.WebAPI.Repositories
#pragma warning disable
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbo;

        public StudentRepository(AppDbContext appDbContext)
        {
            _dbo = appDbContext;
        }
        public async Task CreateAsync(Student entity)
        {
            await _dbo.Students.AddAsync(entity);
            await _dbo.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var student = await _dbo.Students.FindAsync(id);
            _dbo.Students.Remove(student);
            await _dbo.SaveChangesAsync();
        }

        public async Task<Student> FindeAsync(long id)
        {
            var student = await _dbo.Students.FindAsync(id);
            return student;
        }

        public async Task UpdateAsync(long id, Student entity)
        {
            entity.Id = id;
            _dbo.Students.Update(entity);
            await _dbo.SaveChangesAsync();
        }

        public async Task<IQueryable<Student>> GetAllAsync()
        {
            return _dbo.Students.Where(x=>true);
        }
    }
}
