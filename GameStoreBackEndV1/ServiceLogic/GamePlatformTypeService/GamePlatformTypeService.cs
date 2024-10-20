using AutoMapper;
using GameStoreBackEndV1.DataLogic.Game;
using GameStoreBackEndV1.DataLogic.GamePlatformType;
using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.GamePlayformType;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.ServiceLogic.GamePlatformTypeService
{
    public class GamePlatformTypeService : IGamePlatformTypeService
    {
        private readonly IGamePlatformTypeRepository _gamePlatformTypeRepository;
        private readonly IMapper _mapper;

        public GamePlatformTypeService(
            IGamePlatformTypeRepository gamePlatformTypeRepository, IMapper mapper)
        {
            _gamePlatformTypeRepository = gamePlatformTypeRepository;
            _mapper = mapper;
        }

        public async Task<IList<DisplayGamePlatformTypeDto>> GetAllGamePlatformTypeAsync()
        {
            var result = await _gamePlatformTypeRepository.GetAllGamePlatformTypeAsync();

            return _mapper.Map<IList<DisplayGamePlatformTypeDto>>(result);
        }

        public async Task CreateGamePlatformTypeAsync(CreateGamePlatformTypeDto createGamePlatformType)
        {
            await _gamePlatformTypeRepository.CreateGamePlatformTypeAsync(createGamePlatformType);
        }

        public async Task<DisplayGamePlatformTypeDto> GetByPlatformTypeIdAsync(Guid id)
        {
            var result = await _gamePlatformTypeRepository.GetByPlatformTypeIdAsync(id);

            return _mapper.Map<DisplayGamePlatformTypeDto>(result);
        }

        public async Task<DisplayGamePlatformTypeDto> GetByGameIdAsync(Guid id)
        {
            var result = await _gamePlatformTypeRepository.GetByGameIdAsync(id);

            return _mapper.Map<DisplayGamePlatformTypeDto>(result);
        }

        public async Task<DisplayGamePlatformTypeDto> GetByGameNameAsync(string gameName)
        {
            var result = await _gamePlatformTypeRepository.GetByGameNameAsync(gameName);

            return _mapper.Map<DisplayGamePlatformTypeDto>(result);
        }

        public async Task<GameCategoriesDto> GetGameCategoriesAsync()
        {
            var result = await _gamePlatformTypeRepository.GetGameCategoriesAsync();

            return result;
        }
    }
}
