using System.Linq.Expressions;

namespace GameStoreBackEndV1.DataLogic.GenericInterface
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
