using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.PlayerRoleService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerRoleController : ControllerBase
    {
        private readonly IPlayerRoleService _playerRoleService;
        private readonly IMapper _mapper;

        public PlayerRoleController(IPlayerRoleService playerRoleService, IMapper mapper)
        {
            _playerRoleService = playerRoleService;
            _mapper = mapper;
        }

        [HttpPost("CreatePlayerRole")]
        public async Task<IActionResult> Post([FromBody] CreatePlayerRoleDto value)
        {
            await _playerRoleService.CreatePlayerRoleAsync(value);
            return Created();
        }

        [HttpGet("GetPlayerRoles")]
        public async Task<IActionResult> Get()
        {
            var result = await _playerRoleService.GetAllPlayerRoleAsync();
            return Ok(result);
        }

        [HttpGet("GetByPlayerId/{id:guid}")]
        public async Task<IActionResult> GetByPlayerId(Guid id)
        {
            var result = await _playerRoleService.GetByPlayerIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetPlayersByRoleId/{id:guid}")]
        public async Task<IActionResult> GetPlayersByRoleId(Guid id)
        {
            var result = await _playerRoleService.GetPlayersByRoleIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetPlayersByRoleName/{roleName}")]
        public async Task<IActionResult> GetPlayersByRoleName(string roleName)
        {
            var result = await _playerRoleService.GetPlayersByRoleNameAsync(roleName);
            return Ok(result);
        }
    }
}
