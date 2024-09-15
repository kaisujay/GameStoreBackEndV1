using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.CartService
{
    public interface ICartService
    {
        Task<IList<DisplayCartDto>> GetAllAsync();

        Task<DisplayCartDto> GetByIdAsync(Guid id);

        Task<DisplayCartDto> GetByPlayerIdAsync(Guid id);

        Task<CartDto> UpdateAsync(CreateAndUpdateCartDto entity);

        Task RemoveAsync(CreateAndUpdateCartDto entity);
    }
}