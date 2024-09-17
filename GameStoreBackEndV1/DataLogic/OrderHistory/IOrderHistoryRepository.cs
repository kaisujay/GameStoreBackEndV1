using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.OrderHistory
{
    public interface IOrderHistoryRepository
    {
        Task<Guid> CreateAsync(OrderHistoryDto entity);

        Task<IList<OrderHistoryDto>> GetAllAsync();

        Task<IList<OrderHistoryDto>> GetByDateAsync(DateTime dateTime);

        Task<OrderHistoryDto> GetByIdAsync(Guid id);

        Task<IList<OrderHistoryDto>> GetByOrderIdAsync(Guid id);

        Task<IList<OrderHistoryDto>> GetByPlayerIdAsync(Guid id);
    }
}