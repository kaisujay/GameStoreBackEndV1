using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.PlayerService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("GetPlayers")]
        public async Task<IActionResult> Get()
        {
            var players = await _playerService.GetAllAsync();
            return Ok(players);
        }

        [HttpGet("GetPlayerById/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var player = await _playerService.GetByIdAsync(id);
            return Ok(player);
        }

        [HttpPost("CreatePlayer")]
        public async Task<IActionResult> Post([FromBody] CreatePlayerDto createPlayer)
        {
            var createdPlayer = await _playerService.CreateAsync(createPlayer);
            return Created("",createdPlayer);
        }

        [HttpPut("UpdatePlayer/{id:Guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePlayerDto updatePlayer)
        {
            var updatedPlayer = await _playerService.UpdateAsync(id, updatePlayer);
            return Ok(updatedPlayer);
        }

        [HttpDelete("DeletePlayer/{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _playerService.DeleteAsync(id);
            return StatusCode(204);
        }

        [HttpPut("UpdateWallet/{id:Guid}")]
        public async Task<IActionResult> UpdateWallet(Guid id, [FromBody] float walletBalance)
        {
            await _playerService.UpdateWalletBalanceAsync(id, walletBalance);
            return Ok();
        }
    }
}
