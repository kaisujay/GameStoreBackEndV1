using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.WishList
{
    public class WishListRepository : IWishListRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public WishListRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<WishListDto>> GetAllAsync()
        {
            var result = await _dbContext.WishLists
                                .Include(x => x.Game)
                                .Include(x => x.Player)
                                .AsNoTracking()
                                .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException("WishLists not found");
            }
            var mappedResult = _mapper.Map<IList<WishListDto>>(result);

            return mappedResult;
        }

        public async Task<IList<DisplaySingleWishListDto>> GetByGameIdAsync(Guid id)
        {
            var result = await _dbContext.WishLists
                                .Include(x => x.Game)
                                .Include(x => x.Player)
                                .AsNoTracking()     // "AsNoTracking()" : Very IMP while Update
                                .Where(x => x.GameId == id)
                                .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException("WishList is not found with teh GameId");
            }

            var mappedWishList = _mapper.Map<IList<WishListDto>>(result);
            var mappedResult = _mapper.Map<IList<DisplaySingleWishListDto>>(mappedWishList);

            return mappedResult;
        }

        public async Task<DisplayWishListDto> GetByPlayerIdAsync(Guid id)
        {
            var wishiListGameList = await _dbContext.WishLists
                    .Include(x => x.Game)
                    .AsNoTracking()
                    .Where(x => x.PlayerId == id)
                    .Select(x => new DisplayGameDto
                    {
                         GameId = x.Game.GameId,
                         Name = x.Game.Name,
                         DiscountPercent = x.Game.DiscountPercent,
                         GameDetails = x.Game.GameDetails,
                         Price = x.Game.Price
                    })
                    .ToListAsync();

            var wishListPlayerDetails = await _dbContext.WishLists
                    .Include(x => x.Player)
                    .AsNoTracking()                 // "AsNoTracking()" : Very IMP while Update
                    .FirstOrDefaultAsync(x => x.PlayerId == id);

            var displayWishListDto = new DisplayWishListDto()
            {
                Player = _mapper.Map<DisplayPlayerDto>(_mapper.Map<PlayerDto>(wishListPlayerDetails?.Player)),
                Games = wishiListGameList
            };

            if (wishiListGameList == null)
            {
                throw new NotFoundException("WishList is not found with the PlayerId");
            }
            var mappedResult = _mapper.Map<DisplayWishListDto>(displayWishListDto);

            return mappedResult;
        }

        public async Task<WishListDto> UpdateAsync(WishListDto entity)
        {
            var mappedWishList = _mapper.Map<WishListDataModel>(entity);
            _dbContext.WishLists.Add(mappedWishList);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("WishList save changes failed");
            }

            return entity;
        }

        public async Task DeleteAsync(WishListDto deleteFromWishList)
        {
            var mappedGameToBeRemoved = _mapper.Map<WishListDataModel>(deleteFromWishList);
            _dbContext.WishLists.Remove(mappedGameToBeRemoved);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Game remove from WishList failed");
            }
        }
    }
}
