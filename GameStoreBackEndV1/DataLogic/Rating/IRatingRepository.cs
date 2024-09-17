using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using System.Threading.Tasks;

namespace GameStoreBackEndV1.DataLogic.Rating
{
    public interface IRatingRepository
    {
        Task<Guid> CreateAsync(RatingDto entity);

        Task DeleteAsync(RatingDto deleteFromRating);

        Task<IList<RatingDto>> GetAllAsync();

        Task<IList<RatingDto>> GetByGameIdAsync(Guid id);

        Task<RatingDto> GetByIdAsync(Guid id);

        Task<RatingDto> GetByPlayerIdAndGameIdAsync(Guid playerId, Guid gameId);

        Task<IList<RatingDto>> GetByPlayerIdAsync(Guid id);
    }
}