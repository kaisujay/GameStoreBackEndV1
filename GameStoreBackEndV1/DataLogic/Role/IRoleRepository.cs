using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.Role
{
    public interface IRoleRepository
    {
        Task<Guid> CreateAsync(RoleDto entity);
        Task<IList<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByIdAsync(Guid id);
    }
}