namespace Treaning.WebAPI.Common.Interfaces
{
    public interface IFindeable<T>
    {
        Task<T> FindeAsync(long id);
    }
}
