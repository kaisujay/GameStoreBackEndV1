using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.DataLogic.PlatformType
{
    public interface IPlatformTypeRepository
    {
        Task<Guid> CreateAsync(PlatformTypeDto entity);

        Task<IList<PlatformTypeDto>> GetAllAsync();

        Task<PlatformTypeDto> GetByIdAsync(Guid id);

        Task<PlatformTypeDto> GetByNameAsync(string PlatformTypeName);
    }
}