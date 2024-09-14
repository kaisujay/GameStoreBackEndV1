namespace GameStoreBackEndV1.ServiceLogic.GenericInterfaceService
{
    public interface IService<P, C, U, D>
    {
        Task<IList<D>> GetAllAsync();

        Task<D> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(C entity);

        Task<D> UpdateAsync(Guid id, U entity);

        Task DeleteAsync(Guid id);
    }
}
