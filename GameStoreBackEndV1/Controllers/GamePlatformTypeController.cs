using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.GamePlatformTypeService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePlatformTypeController : ControllerBase
    {
        private readonly IGamePlatformTypeService _gamePlatformTypeService;
        private readonly IMapper _mapper;

        public GamePlatformTypeController(IGamePlatformTypeService gamePlatformTypeService, IMapper mapper)
        {
            _gamePlatformTypeService = gamePlatformTypeService;
            _mapper = mapper;
        }

        [HttpGet("GetGamePlatformTypes")]
        public async Task<IActionResult> Get()
        {
            var res = await _gamePlatformTypeService.GetAllGamePlatformTypeAsync();
            return Ok(res);
        }

        [HttpGet("GetByPlatformTypeId/{id:guid}")]
        public async Task<IActionResult> GetByPlatformTypeId(Guid id)
        {
            var res = await _gamePlatformTypeService.GetByPlatformTypeIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByGameId/{id:guid}")]
        public async Task<IActionResult> GetByGameIdAsync(Guid id)
        {
            var res = await _gamePlatformTypeService.GetByGameIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByGameName/{gameName}")]
        public async Task<IActionResult> GetByGameNameAsync(string gameName)
        {
            var res = await _gamePlatformTypeService.GetByGameNameAsync(gameName);
            return Ok(res);
        }

        [HttpPost("CreateGamePlatformType")]
        public async Task<IActionResult> Post([FromBody] CreateGamePlatformTypeDto createGamePlatformType)
        {
            await _gamePlatformTypeService.CreateGamePlatformTypeAsync(createGamePlatformType);
            return Created();
        }
    }
}
