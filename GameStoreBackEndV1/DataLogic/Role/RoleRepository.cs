using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoleRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<RoleDto>> GetAllAsync()
        {
            var result = await _dbContext.Roles.ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("Roles not found");
            }
            var mappedResult = _mapper.Map<IList<RoleDto>>(result);

            return mappedResult;
        }

        public async Task<RoleDto> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.RoleId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Role is not found");
            }
            var mappedResult = _mapper.Map<RoleDto>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(RoleDto entity)
        {
            var mappedRole = _mapper.Map<RoleTableDataModel>(entity);
            _dbContext.Roles.Add(mappedRole);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("Role save changes failed");
            }

            return entity.RoleId;
        }

        public async Task<RoleDto> GetByNameAsync(string roleName)
        {
            var result = await _dbContext.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.RoleName == roleName);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Role is not found");
            }
            var mappedResult = _mapper.Map<RoleDto>(result);

            return mappedResult;
        }
    }
}
