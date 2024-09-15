using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CartRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<CartDto>> GetAllAsync()
        {
            var result = await _dbContext.Carts
                                .Include(x=>x.Game)
                                .Include(x => x.Player)
                                .ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("Carts not found");
            }
            var mappedResult = _mapper.Map<IList<CartDto>>(result);

            return mappedResult;
        }

        public async Task<CartDto> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Carts
                                .Include(x => x.Game)
                                .Include(x => x.Player)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.CartId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Cart is not found");
            }
            var mappedResult = _mapper.Map<CartDto>(result);

            return mappedResult;
        }

        public async Task<CartDto> GetByPlayerIdAsync(Guid id)
        {
            var result = await _dbContext.Carts
                                .Include(x => x.Game)
                                .Include(x => x.Player)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.PlayerId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Cart is not found");
            }
            var mappedResult = _mapper.Map<CartDto>(result);

            return mappedResult;
        }

        public async Task<CartDto> UpdateAsync(CartDto entity)
        {
            var mappedCart = _mapper.Map<CartDataModel>(entity);
            _dbContext.Carts.Add(mappedCart);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Cart save changes failed");
            }

            return entity;
        }

        public async Task DeleteAsync(CartDto deleteFromCart)
        {
            var mappedGameToBeRemoved = _mapper.Map<CartDataModel>(deleteFromCart);
            _dbContext.Carts.Remove(mappedGameToBeRemoved);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Game remove from Cart failed");
            }
        }
    }
}
