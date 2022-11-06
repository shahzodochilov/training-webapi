using Treaning.WebAPI.Common.Interfaces;

namespace Treaning.WebAPI.Interfaces.Repositories
{
    public interface IGenericRepository<T>:
        ICreateable<T>, IFindeable<T>,
        IUpdateable<T>, IDeleteable<T>,
        ISearchable<T>
    {

    }
}
