using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.Game
{
    public class GameRepository : IGameRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GameRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<GameDto>> GetAllAsync()
        {
            var result = await _dbContext.Games.ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("Games not found");
            }
            var mappedResult = _mapper.Map<IList<GameDto>>(result);

            return mappedResult;
        }

        public async Task<GameDto> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Games.AsNoTracking().FirstOrDefaultAsync(x => x.GameId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Game is not found");
            }
            var mappedResult = _mapper.Map<GameDto>(result);

            return mappedResult;
        }

        public async Task<IList<GameDto>> GetAllByNameAsync(string gameName)
        {
            var result = await _dbContext.Games.Where(x => x.Name.ToLower().Contains(gameName.ToLower())).ToListAsync();      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Game is not found");
            }
            var mappedResult = _mapper.Map<IList<GameDto>>(result);

            return mappedResult;
        }

        public async Task<GameDto> GetOneByNameAsync(string gameName)
        {
            var result = await _dbContext.Games.Where(x => x.Name.ToLower().Contains(gameName.ToLower())).FirstOrDefaultAsync();      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Game is not found");
            }
            var mappedResult = _mapper.Map<GameDto>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(GameDto entity)
        {
            var mappedGame = _mapper.Map<GameDataModel>(entity);
            _dbContext.Games.Add(mappedGame);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Game save changes failed");
            }

            return entity.GameId;
        }

        public async Task<GameDto> UpdateAsync(GameDto entity)
        {
            var baseEntry = await GetByIdAsync(entity.GameId);
            var mappedBaseEntry = _mapper.Map<GameDataModel>(baseEntry);
            var mappedGame = _mapper.Map<GameDataModel>(entity);

            _dbContext.Entry(mappedBaseEntry).CurrentValues.SetValues(mappedGame);        //Very IMP while Update
            _dbContext.Entry(mappedBaseEntry).State = EntityState.Modified;                 //Very IMP while Update

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Player update changes failed");
            }

            return await GetByIdAsync(entity.GameId);
        }
    }
}
