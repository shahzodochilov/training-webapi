namespace Treaning.WebAPI.Common.Interfaces
{
    public interface IUpdateable<T>
    {
        Task UpdateAsync(long id,T entity);
    }
}
