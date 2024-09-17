using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.RatingService
{
    public interface IRatingService
    {
        Task<Guid> CreateAsync(CreateRatingDto entity);

        Task<IList<DisplayRatingDto>> GetAllAsync();

        Task<IList<DisplayRatingDto>> GetByGameIdAsync(Guid id);

        Task<DisplayRatingDto> GetByIdAsync(Guid id);

        Task<IList<DisplayRatingDto>> GetByPlayerIdAsync(Guid id);

        Task RemoveAsync(DeleteRatingDto entity);
    }
}