using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.PlayerRole
{
    public interface IPlayerRoleRepository
    {
        Task CreatePlayerRoleAsync(PlayerRoleTableDto playerRole);

        Task<IList<PlayerRoleDto>> GetAllPlayerRoleAsync();

        Task<PlayerRoleDto> GetByPlayerIdAsync(Guid id);

        Task<IList<PlayerRoleDto>> GetPlayersByRoleIdAsync(Guid id);

        Task<IList<PlayerRoleDto>> GetPlayersByRoleNameAsync(string roleName);
    }
}