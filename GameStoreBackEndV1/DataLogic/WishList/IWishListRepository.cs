using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.WishList
{
    public interface IWishListRepository
    {
        Task DeleteAsync(WishListDto deleteFromWishList);

        Task<IList<WishListDto>> GetAllAsync();

        Task<IList<DisplaySingleWishListDto>> GetByGameIdAsync(Guid id);

        Task<DisplayWishListDto> GetByPlayerIdAsync(Guid id);

        Task<WishListDto> UpdateAsync(WishListDto entity);
    }
}