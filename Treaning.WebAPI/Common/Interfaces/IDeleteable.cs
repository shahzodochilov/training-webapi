namespace Treaning.WebAPI.Common.Interfaces
{
    public interface IDeleteable<T>
    {
        Task<bool> DeleteAsync(long id);
    }
}
