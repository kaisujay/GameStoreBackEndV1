using AutoMapper;
using GameStoreBackEndV1.DataLogic.PlayerRole;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;
using GameStoreBackEndV1.ServiceLogic.PlayerService;
using GameStoreBackEndV1.ServiceLogic.RoleService;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace GameStoreBackEndV1.ServiceLogic.PlayerRoleService
{
    public class PlayerRoleService : IPlayerRoleService
    {
        private readonly IPlayerRoleRepository _playerRoleRepository;
        private readonly IPlayerService _playerService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public PlayerRoleService(
            IPlayerRoleRepository playerRoleRepository,
            IPlayerService playerService,
            IRoleService roleService,
            IMapper mapper)
        {
            _playerRoleRepository = playerRoleRepository;
            _playerService = playerService;
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task CreatePlayerRoleAsync(CreatePlayerRoleDto createPlayerRole)
        {
            var selectedPlayerByEmail = await _playerService.GetByEmailAsync(createPlayerRole.PlayerEmail);
            var selectedRole = await _roleService.GetByNameAsync(createPlayerRole.RoleName);

            var playerRole = new PlayerRoleTableDto()
            {

                PlayerRoleId = Guid.NewGuid(),
                PlayerId = selectedPlayerByEmail.PlayerId,
                RoleId = selectedRole.RoleId
            };

            await _playerRoleRepository.CreatePlayerRoleAsync(playerRole);
        }

        public async Task<IList<PlayerRoleTableDto>> GetAllPlayerRoleAsync()
        {
            var result = await _playerRoleRepository.GetAllPlayerRoleAsync();

            return _mapper.Map<IList<PlayerRoleTableDto>>(result);
        }

        public async Task<PlayerRoleTableDto> GetByPlayerIdAsync(Guid id)
        {
            var result = await _playerRoleRepository.GetByPlayerIdAsync(id);

            return _mapper.Map<PlayerRoleTableDto>(result);
        }

        public async Task<IList<PlayerRoleTableDto>> GetPlayersByRoleIdAsync(Guid id)
        {
            var result = await _playerRoleRepository.GetPlayersByRoleIdAsync(id);

            return _mapper.Map<IList<PlayerRoleTableDto>>(result);
        }

        public async Task<IList<PlayerRoleTableDto>> GetPlayersByRoleNameAsync(string roleName)
        {
            var result = await _playerRoleRepository.GetPlayersByRoleNameAsync(roleName);

            return _mapper.Map<IList<PlayerRoleTableDto>>(result);
        }
    }
}
