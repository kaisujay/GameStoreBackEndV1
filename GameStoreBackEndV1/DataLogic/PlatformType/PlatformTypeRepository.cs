using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.PlatformType
{
    public class PlatformTypeRepository : IPlatformTypeRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlatformTypeRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<PlatformTypeDto>> GetAllAsync()
        {
            var result = await _dbContext.PlatformTypes.ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("PlatformTypes not found");
            }
            var mappedResult = _mapper.Map<IList<PlatformTypeDto>>(result);

            return mappedResult;
        }

        public async Task<PlatformTypeDto> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.PlatformTypes.AsNoTracking().FirstOrDefaultAsync(x => x.PlatformTypeId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("PlatformType is not found");
            }
            var mappedResult = _mapper.Map<PlatformTypeDto>(result);

            return mappedResult;
        }

        public async Task<PlatformTypeDto> GetByNameAsync(string PlatformTypeName)
        {
            var result = await _dbContext.PlatformTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Name == PlatformTypeName);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("PlatformType is not found");
            }
            var mappedResult = _mapper.Map<PlatformTypeDto>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(PlatformTypeDto entity)
        {
            var mappedPlatformType = _mapper.Map<PlatformTypeDataModel>(entity);
            _dbContext.PlatformTypes.Add(mappedPlatformType);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("PlatformType save changes failed");
            }

            return entity.PlatformTypeId;
        }
    }
}
