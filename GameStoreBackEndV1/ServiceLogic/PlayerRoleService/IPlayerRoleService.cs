using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.PlayerRoleService
{
    public interface IPlayerRoleService
    {
        Task CreatePlayerRoleAsync(CreatePlayerRoleDto createPlayerRole);

        Task<IList<PlayerRoleTableDto>> GetAllPlayerRoleAsync();

        Task<PlayerRoleTableDto> GetByPlayerIdAsync(Guid id);

        Task<IList<PlayerRoleTableDto>> GetPlayersByRoleIdAsync(Guid id);

        Task<IList<PlayerRoleTableDto>> GetPlayersByRoleNameAsync(string roleName);
    }
}