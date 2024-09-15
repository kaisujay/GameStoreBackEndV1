using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.GamePlatformTypeService
{
    public interface IGamePlatformTypeService
    {
        Task CreateGamePlatformTypeAsync(CreateGamePlatformTypeDto createGamePlatformType);

        Task<IList<DisplayGamePlatformTypeDto>> GetAllGamePlatformTypeAsync();

        Task<DisplayGamePlatformTypeDto> GetByGameIdAsync(Guid id);

        Task<DisplayGamePlatformTypeDto> GetByGameNameAsync(string gameName);

        Task<DisplayGamePlatformTypeDto> GetByPlatformTypeIdAsync(Guid id);
    }
}