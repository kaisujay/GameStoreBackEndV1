using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.OrderHistoryService
{
    public interface IOrderHistoryService
    {
        Task<Guid> CreateAsync(CreateOrderHistoryDto entity);

        Task<IList<OrderHistoryDto>> GetAllAsync();

        Task<IList<OrderHistoryDto>> GetByDateAsync(DateTime dateTime);

        Task<OrderHistoryDto> GetByIdAsync(Guid id);

        Task<IList<OrderHistoryDto>> GetByOrderIdAsync(Guid id);

        Task<IList<OrderHistoryDto>> GetByPlayerIdAsync(Guid id);
    }
}