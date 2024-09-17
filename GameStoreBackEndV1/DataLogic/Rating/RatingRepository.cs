using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.Rating
{
    public class RatingRepository : IRatingRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public RatingRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<RatingDto>> GetAllAsync()
        {
            var result = await _dbContext.Ratings
                .Include(x=>x.Player)
                .Include(x => x.Game)
                .AsNoTracking()
                .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException("All Ratings not found");
            }
            var mappedResult = _mapper.Map<IList<RatingDto>>(result);

            return mappedResult;
        }

        public async Task<RatingDto> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Ratings
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.RatingId == id);      // "AsNoTracking()" : Very IMP while Update

            if (result == null)
            {
                throw new NotFoundException("Rating by Id is not found");
            }
            var mappedResult = _mapper.Map<RatingDto>(result);

            return mappedResult;
        }

        public async Task<IList<RatingDto>> GetByPlayerIdAsync(Guid id)
        {
            var result = await _dbContext.Ratings
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking().Where(x => x.PlayerId == id)
                .ToListAsync();      // "AsNoTracking()" : Very IMP while Update

            if (result == null)
            {
                throw new NotFoundException("Rating by PlayerId is not found");
            }
            var mappedResult = _mapper.Map<IList<RatingDto>>(result);

            return mappedResult;
        }

        public async Task<IList<RatingDto>> GetByGameIdAsync(Guid id)
        {
            var result = await _dbContext.Ratings
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking()
                .Where(x => x.GameId == id)
                .ToListAsync();      // "AsNoTracking()" : Very IMP while Update

            if (result == null)
            {
                throw new NotFoundException("Rating by GameId is not found");
            }
            var mappedResult = _mapper.Map<IList<RatingDto>>(result);

            return mappedResult;
        }

        public async Task<RatingDto> GetByPlayerIdAndGameIdAsync(Guid playerId, Guid gameId)
        {
            var result = await _dbContext.Ratings
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking()
                .Where(x => x.GameId == gameId && x.PlayerId == playerId)
                .FirstOrDefaultAsync();      // "AsNoTracking()" : Very IMP while Update

            var mappedResult = _mapper.Map<RatingDto>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(RatingDto entity)
        {
            var mappedRating = _mapper.Map<RatingDataModel>(entity);
            _dbContext.Ratings.Add(mappedRating);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Rating save changes failed");
            }

            return entity.RatingId;
        }

        public async Task DeleteAsync(RatingDto deleteFromRating)
        {
            var mappedGameToBeRemoved = _mapper.Map<RatingDataModel>(deleteFromRating);
            _dbContext.Ratings.Remove(mappedGameToBeRemoved);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Rating remove failed");
            }
        }
    }
}
