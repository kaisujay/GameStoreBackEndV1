using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.GamePlatformType
{
    public class GamePlatformTypeRepository : IGamePlatformTypeRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GamePlatformTypeRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateGamePlatformTypeAsync(CreateGamePlatformTypeDto createGamePlatformType)
        {
            var mappedGamePlatformTypeDto = _mapper.Map<GamePlatformTypeDto>(createGamePlatformType);
            var mappedGamePlatformType = _mapper.Map<GamePlatformTypeDataModel>(mappedGamePlatformTypeDto);

            _dbContext.GamePlatformTypes.Add(mappedGamePlatformType);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("GamePlatformType save changes failed");
            }
        }

        public async Task<IList<GamePlatformTypeDto>> GetAllGamePlatformTypeAsync()
        {
            var result = await _dbContext.GamePlatformTypes.ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("GamePlatformTypes not found");
            }

            var mappedResult = _mapper.Map<IList<GamePlatformTypeDto>>(result);

            return mappedResult;
        }

        public async Task<GamePlatformTypeDto> GetByPlatformTypeIdAsync(Guid id)
        {
            var result = await _dbContext.GamePlatformTypes.AsNoTracking().FirstOrDefaultAsync(x => x.PlatformTypeId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("GamePlatformTypes is not found");
            }
            var mappedResult = _mapper.Map<GamePlatformTypeDto>(result);

            return mappedResult;
        }

        public async Task<GamePlatformTypeDto> GetByGameIdAsync(Guid id)
        {
            var result = await _dbContext.GamePlatformTypes.AsNoTracking().FirstOrDefaultAsync(x => x.GameId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("GamePlatformTypes is not found");
            }
            var mappedResult = _mapper.Map<GamePlatformTypeDto>(result);

            return mappedResult;
        }

        public async Task<GamePlatformTypeDto> GetByGameNameAsync(string gameName)
        {
            var result = await _dbContext.GamePlatformTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Game.Name.ToLower().Contains(gameName.ToLower()));      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("GamePlatformTypes is not found");
            }
            var mappedResult = _mapper.Map<GamePlatformTypeDto>(result);

            return mappedResult;
        }
    }
}
