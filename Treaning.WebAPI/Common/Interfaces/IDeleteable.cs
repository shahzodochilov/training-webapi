namespace Treaning.WebAPI.Common.Interfaces
{
    public interface IDeleteable<T>
    {
        Task DeleteAsync(long id);
    }
}
