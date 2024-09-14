namespace GameStoreBackEndV1.ServiceLogic.GenericInterfaceService
{
    public interface IService<P, C, U, D>
    {
        Task<IList<P>> GetAllAsync();

        Task<P> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(C entity);

        Task<P> UpdateAsync(Guid id, U entity);

        Task DeleteAsync(Guid id);
    }
}
