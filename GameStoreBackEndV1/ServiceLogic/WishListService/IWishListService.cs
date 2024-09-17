using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.WishListService
{
    public interface IWishListService
    {
        Task<IList<WishListDto>> GetAllAsync();

        Task<IList<DisplaySingleWishListDto>> GetByGameIdAsync(Guid id);

        Task<DisplayWishListDto> GetByPlayerIdAsync(Guid id);

        Task RemoveAsync(CreateWishListDto entity);

        Task<WishListOnlyIdDto> UpdateAsync(CreateWishListDto entity);
    }
}