﻿using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.GamePlatformType
{
    public interface IGamePlatformTypeRepository
    {
        Task CreateGamePlatformTypeAsync(CreateGamePlatformTypeDto createGamePlatformType);

        Task<IList<GamePlatformTypeDto>> GetAllGamePlatformTypeAsync();

        Task<GamePlatformTypeDto> GetByGameIdAsync(Guid id);

        Task<GamePlatformTypeDto> GetByGameNameAsync(string gameName);

        Task<GamePlatformTypeDto> GetByPlatformTypeIdAsync(Guid id);
    }
}