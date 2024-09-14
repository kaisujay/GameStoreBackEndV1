using AutoMapper;
using GameStoreBackEndV1.NuGetDependencies;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic.PlayerRole
{
    public class PlayerRoleRepository : IPlayerRoleRepository
    {
        private readonly GameStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlayerRoleRepository(GameStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreatePlayerRoleAsync(PlayerRoleTableDto playerRole)
        {
            var mappedPlayerRole = _mapper.Map<PlayerRoleTableDataModel>(playerRole);

            _dbContext.PlayerRoles.Add(mappedPlayerRole);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("PlayerRole save changes failed");
            }
        }

        public async Task<IList<PlayerRoleDto>> GetAllPlayerRoleAsync()
        {
            var result = await _dbContext.PlayerRoles.ToListAsync();
            if (result == null)
            {
                throw new NotFoundException("PlayerRoles not found");
            }

            var mappedResult = _mapper.Map<IList<PlayerRoleDto>>(result);

            return mappedResult;
        }

        public async Task<PlayerRoleDto> GetByPlayerIdAsync(Guid id)
        {
            var result = await _dbContext.PlayerRoles.AsNoTracking().FirstOrDefaultAsync(x => x.PlayerId == id);      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("PlayerRole is not found");
            }
            var mappedResult = _mapper.Map<PlayerRoleDto>(result);

            return mappedResult;
        }

        public async Task<IList<PlayerRoleDto>> GetPlayersByRoleIdAsync(Guid id)
        {
            var result = await _dbContext.PlayerRoles.AsNoTracking().Where(x => x.RoleId == id).ToListAsync();      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Players is not found with the RoleId");
            }
            var mappedResult = _mapper.Map<IList<PlayerRoleDto>>(result);

            return mappedResult;
        }

        public async Task<IList<PlayerRoleDto>> GetPlayersByRoleNameAsync(string roleName)
        {
            var result = await _dbContext.PlayerRoles.AsNoTracking().Where(x => x.Role.RoleName == roleName).ToListAsync();      // "AsNoTracking()" : Very IMP while Update
            if (result == null)
            {
                throw new NotFoundException("Players is not found with the RoleName");
            }
            var mappedResult = _mapper.Map<IList<PlayerRoleDto>>(result);

            return mappedResult;
        }
    }
}
