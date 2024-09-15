using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.GameService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet("GetGames")]
        public async Task<IActionResult> Get()
        {
            var res = await _gameService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("GetGameById/{id:guid}")]
        public async Task<IActionResult> GetGameById(Guid id)
        {
            var res = await _gameService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetGamesByName/{gameName}")]
        public async Task<IActionResult> GetAllByNameAsync(string gameName)
        {
            var res = await _gameService.GetAllByNameAsync(gameName);
            return Ok(res);
        }

        [HttpGet("GetOneGameByName/{gameName}")]
        public async Task<IActionResult> GetOneByNameAsync(string gameName)
        {
            var res = await _gameService.GetOneByNameAsync(gameName);
            return Ok(res);
        }

        [HttpPost("CreateGame")]
        public async Task<IActionResult> Post([FromBody] CreateAndUpdateGameDto createGame)
        {
            var res = await _gameService.CreateAsync(createGame);
            return Created("",res);
        }

        [HttpPut("UpdateGame/{gameId:guid}")]
        public async Task<IActionResult> Put(Guid gameId, [FromBody] CreateAndUpdateGameDto updateGame)
        {
            var res = await _gameService.UpdateAsync(gameId, updateGame);
            return Ok(res);
        }
    }
}
