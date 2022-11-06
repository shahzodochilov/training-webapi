using System.Linq.Expressions;

namespace Treaning.WebAPI.Common.Interfaces
{
    public interface ISearchable<T>
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
