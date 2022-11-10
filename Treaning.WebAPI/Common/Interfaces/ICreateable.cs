namespace Treaning.WebAPI.Common.Interfaces
{
    public interface ICreateable<T>
    {
        Task CreateAsync(T entity);
    }
}
