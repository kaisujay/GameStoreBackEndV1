using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.Game
{
    public interface IGameRepository
    {
        Task<Guid> CreateAsync(GameDto entity);

        Task<IList<GameDto>> GetAllAsync();

        Task<IList<GameDto>> GetAllByNameAsync(string gameName);

        Task<GameDto> GetByIdAsync(Guid id);

        Task<GameDto> GetOneByNameAsync(string gameName);

        Task<GameDto> UpdateAsync(GameDto entity);
    }
}