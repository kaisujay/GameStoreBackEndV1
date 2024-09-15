using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.Cart
{
    public interface ICartRepository
    {
        Task<IList<CartDto>> GetAllAsync();

        Task<CartDto> GetByIdAsync(Guid id);

        Task<CartDto> GetByPlayerIdAsync(Guid id);

        Task<CartDto> UpdateAsync(CartDto entity);

        Task DeleteAsync(CartDto deleteFromCart);
    }
}