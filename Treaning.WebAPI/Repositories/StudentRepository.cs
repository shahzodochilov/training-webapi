using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Treaning.WebAPI.Data;
using Treaning.WebAPI.Interfaces.Repositories;
using Treaning.WebAPI.Models;

namespace Treaning.WebAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbo;

        public StudentRepository(AppDbContext appDbContext)
        {
            _dbo = appDbContext;
        }
        public async Task<bool> CreateAsync(Student entity)
        {
            await _dbo.Students.AddAsync(entity);
            await _dbo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var student = await _dbo.Students.FindAsync(id);
            if(student is not null)
            {
                _dbo.Students.Remove(student);
                await _dbo.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<Student> FindeAsync(long id)
        {
            var student = await _dbo.Students.FindAsync(id);
            if(student is not null)
            {
                return student;
            }
            else return new Student();
        }

        public async Task<bool> UpdateAsync(long id, Student entity)
        {
            var student = await _dbo.Students.FindAsync(id);
            if (student is not null)
            {
                entity.Id = id;
                _dbo.Students.Update(entity);
                await _dbo.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<IQueryable<Student>> GetAllAsync()
        {
            return _dbo.Students.Where(x=>true);
        }
    }
}
