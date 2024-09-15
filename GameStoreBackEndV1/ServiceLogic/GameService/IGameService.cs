using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.GameService
{
    public interface IGameService
    {
        Task<Guid> CreateAsync(CreateAndUpdateGameDto entity);

        Task<IList<DisplayGameDto>> GetAllAsync();

        Task<IList<DisplayGameDto>> GetAllByNameAsync(string gameName);

        Task<DisplayGameDto> GetByIdAsync(Guid id);

        Task<DisplayGameDto> GetOneByNameAsync(string gameName);

        Task<GameDto> UpdateAsync(Guid id, CreateAndUpdateGameDto entity);
    }
}