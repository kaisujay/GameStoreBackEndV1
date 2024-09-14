using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.RoleService
{
    public interface IRoleService
    {
        Task<Guid> CreateAsync(CreateRoleDto entity);
        Task<IList<DisplayRoleDto>> GetAllAsync();
        Task<DisplayRoleDto> GetByIdAsync(Guid id);
    }
}