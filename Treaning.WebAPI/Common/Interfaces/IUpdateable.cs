namespace Treaning.WebAPI.Common.Interfaces
{
    public interface IUpdateable<T>
    {
        Task<bool> UpdateAsync(long id,T entity);
    }
}
