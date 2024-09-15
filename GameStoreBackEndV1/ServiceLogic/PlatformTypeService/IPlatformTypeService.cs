using GameStoreBackEndV1.ObjectLogic.TableDataModels;

namespace GameStoreBackEndV1.ServiceLogic.PlatformTypeService
{
    public interface IPlatformTypeService
    {
        Task<Guid> CreateAsync(CreatePlatformTypeDto entity);

        Task<IList<DisplayPlatformTypeDto>> GetAllAsync();

        Task<DisplayPlatformTypeDto> GetByIdAsync(Guid id);

        Task<DisplayPlatformTypeDto> GetByNameAsync(string PlatformTypeName);
    }
}