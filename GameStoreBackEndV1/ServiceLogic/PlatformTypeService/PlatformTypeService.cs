using AutoMapper;
using GameStoreBackEndV1.DataLogic.PlatformType;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;

namespace GameStoreBackEndV1.ServiceLogic.PlatformTypeService
{
    public class PlatformTypeService : IPlatformTypeService
    {
        private readonly IPlatformTypeRepository _platformTypeRepository;
        private readonly IMapper _mapper;

        public PlatformTypeService(IPlatformTypeRepository platformTypeRepository, IMapper mapper)
        {
            _platformTypeRepository = platformTypeRepository;
            _mapper = mapper;
        }

        public async Task<IList<DisplayPlatformTypeDto>> GetAllAsync()
        {
            var result = await _platformTypeRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<DisplayPlatformTypeDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayPlatformTypeDto> GetByIdAsync(Guid id)
        {
            var result = await _platformTypeRepository.GetByIdAsync(id);
            var mappedResult = _mapper.Map<DisplayPlatformTypeDto>(result);

            return mappedResult;
        }

        public async Task<DisplayPlatformTypeDto> GetByNameAsync(string PlatformTypeName)
        {
            var result = await _platformTypeRepository.GetByNameAsync(PlatformTypeName);
            var mappedResult = _mapper.Map<DisplayPlatformTypeDto>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(CreatePlatformTypeDto entity)
        {
            var allCurrentPlatformTypes = await _platformTypeRepository.GetAllAsync();
            var isPlatformTypeExists = allCurrentPlatformTypes.Where(x => x.Name.ToLower() == entity.Name.ToLower()).SingleOrDefault();

            if (isPlatformTypeExists != null)
            {
                throw new DataAlreadyExistsException("PlatformType already exists");
            }

            var PlatformTypeId = Guid.NewGuid();
            var mappedPlatformType = _mapper.Map<PlatformTypeDto>(entity);

            mappedPlatformType.PlatformTypeId = PlatformTypeId;

            var newCreatedGuid = await _platformTypeRepository.CreateAsync(mappedPlatformType);

            return newCreatedGuid;
        }
    }
}
