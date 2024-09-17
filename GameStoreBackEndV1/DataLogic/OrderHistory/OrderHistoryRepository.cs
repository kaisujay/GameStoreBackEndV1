using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.OrderHistory
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderHistoryRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<OrderHistoryDto>> GetAllAsync()
        {
            var result = await _dbContext.OrderHistorys
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking()      // "AsNoTracking()" : Very IMP while Update
                .ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("OrderHistorys not found");
            }
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<OrderHistoryDto> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.OrderHistorys
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking()      // "AsNoTracking()" : Very IMP while Update
                .FirstOrDefaultAsync(x => x.OrderHistoryId == id);

            if (result == null)
            {
                throw new NotFoundException("OrderHistory by Id is not found");
            }
            var mappedResult = _mapper.Map<OrderHistoryDto>(result);

            return mappedResult;
        }

        public async Task<IList<OrderHistoryDto>> GetByOrderIdAsync(Guid id)
        {
            var result = await _dbContext.OrderHistorys
                .Include(x => x.Player)
                .AsNoTracking()      // "AsNoTracking()" : Very IMP while Update
                .Where(x => x.OrderId == id)
                .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException("OrderHistory by OrderId is not found");
            }
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<IList<OrderHistoryDto>> GetByPlayerIdAsync(Guid id)
        {
            var result = await _dbContext.OrderHistorys
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking()      // "AsNoTracking()" : Very IMP while Update
                .Where(x => x.PlayerId == id)                
                .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException("OrderHistory by PlayerId is not found");
            }
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<IList<OrderHistoryDto>> GetByDateAsync(DateTime dateTime)
        {
            var result = await _dbContext.OrderHistorys
                .Include(x => x.Player)
                .Include(x => x.Game)
                .AsNoTracking()      // "AsNoTracking()" : Very IMP while Update
                .Where(x => x.PurchaseDate.Date == dateTime.Date)
                .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException("OrderHistory by Date is not found");
            }
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(OrderHistoryDto entity)
        {
            var mappedOrderHistory = _mapper.Map<OrderHistoryDataModel>(entity);
            _dbContext.OrderHistorys.Add(mappedOrderHistory);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("OrderHistory save changes failed");
            }

            return entity.OrderHistoryId;
        }
    }
}
