using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.GamePlayformType;
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

        public async Task<GameCategoriesDto> GetGameCategoriesAsync()
        {
            var categoryCounts = new Dictionary<Platforms, int> {
                { Platforms.All, 0 },
                { Platforms.PlayStation, 0 },
                { Platforms.PC, 0 },
                { Platforms.Xbox, 0 },
            };

            var categories = await _dbContext.GamePlatformTypes
                                    .AsNoTracking()
                                    .Include(x => x.PlatformType)
                                    .GroupBy(x => new { x.PlatformTypeId, x.PlatformType.Name })
                                    .Select(g => new { g.Key.Name, Count = g.Count() })
                                    .ToListAsync();

            foreach (var category in categories)
            {
                if (Enum.TryParse<Platforms>(category.Name, out var platform))
                {
                    categoryCounts[platform] = categoryCounts.GetValueOrDefault(platform) + category.Count;
                }
                categoryCounts[Platforms.All] += category.Count;
            }

            return new GameCategoriesDto { Categories = categoryCounts };
        }

        public async Task<IList<GamePlatformTypeDto>> GetGameByCategoryAsync(string catagoryName = "All")
        {
            var result = new List<GamePlatformTypeDataModel>();
            if (catagoryName != "All")
            {
                result = await _dbContext.GamePlatformTypes
                        .AsNoTracking()
                        .Include(x => x.PlatformType).AsNoTracking()
                        .Include(x => x.Game).AsNoTracking()
                        .Where(x => x.PlatformType.Name.Contains(catagoryName.ToLower()))
                        .ToListAsync();      // "AsNoTracking()" : Very IMP while Update
            }
            else
            {
                result = await _dbContext.GamePlatformTypes
                        .AsNoTracking()
                        .Include(x => x.PlatformType).AsNoTracking()
                        .Include(x => x.Game).AsNoTracking()
                        .ToListAsync();      // "AsNoTracking()" : Very IMP while Update
            }


            if (result == null)
            {
                throw new NotFoundException("GamePlatformTypes is not found for the Selected Category");
            }

            var mappedResult = _mapper.Map<IList<GamePlatformTypeDto>>(result);

            return mappedResult;
        }

    }
}
