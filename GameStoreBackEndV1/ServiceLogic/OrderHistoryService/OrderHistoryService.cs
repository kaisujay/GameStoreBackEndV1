using AutoMapper;
using GameStoreBackEndV1.DataLogic.Game;
using GameStoreBackEndV1.DataLogic.OrderHistory;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.OrderHistoryService
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public OrderHistoryService(
            IOrderHistoryRepository orderHistoryRepository,
            IGameRepository gameRepository,
            IMapper mapper)
        {
            _orderHistoryRepository = orderHistoryRepository;
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<IList<OrderHistoryDto>> GetAllAsync()
        {
            var result = await _orderHistoryRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<OrderHistoryDto> GetByIdAsync(Guid id)
        {
            var result = await _orderHistoryRepository.GetByIdAsync(id);
            var mappedResult = _mapper.Map<OrderHistoryDto>(result);

            return mappedResult;
        }

        public async Task<IList<OrderHistoryDto>> GetByPlayerIdAsync(Guid id)
        {
            var result = await _orderHistoryRepository.GetByPlayerIdAsync(id);
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<IList<OrderHistoryDto>> GetByOrderIdAsync(Guid id)
        {
            var result = await _orderHistoryRepository.GetByOrderIdAsync(id);
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<IList<OrderHistoryDto>> GetByDateAsync(DateTime dateTime)
        {
            var result = await _orderHistoryRepository.GetByDateAsync(dateTime);
            var mappedResult = _mapper.Map<IList<OrderHistoryDto>>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(CreateOrderHistoryDto entity)
        {
            var orderId = Guid.NewGuid();

            foreach (var gameId in entity.GameId)
            {
                var getGame = await _gameRepository.GetByIdAsync(gameId);
                var createOrder = new OrderHistoryDto();
                createOrder.GameId = gameId;
                createOrder.OrderId = orderId;
                createOrder.OrderHistoryId = Guid.NewGuid();
                createOrder.PlayerId = entity.PlayerId;
                createOrder.PurchaseDate = DateTime.Now;
                createOrder.PurchaseAmmount = getGame.Price;

                var res = await _orderHistoryRepository.CreateAsync(createOrder);
            }

            return orderId;
        }
    }
}
