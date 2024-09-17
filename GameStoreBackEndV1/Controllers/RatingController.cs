using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.RatingService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("GetRatings")]
        public async Task<IActionResult> Get()
        {
            var res = await _ratingService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var res = await _ratingService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByGameId/{id:guid}")]
        public async Task<IActionResult> GetByGameIdAsync(Guid id)
        {
            var res = await _ratingService.GetByGameIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByPlayerId/{id:guid}")]
        public async Task<IActionResult> GetByPlayerIdAsync(Guid id)
        {
            var res = await _ratingService.GetByPlayerIdAsync(id);
            return Ok(res);
        }

        [HttpPut("AddToRating")]
        public async Task<IActionResult> Put(CreateRatingDto entity)
        {
            var res = await _ratingService.CreateAsync(entity);
            return Created("", res);
        }

        [HttpDelete("RemoveRating")]
        public async Task<IActionResult> Delete(DeleteRatingDto entity)
        {
            await _ratingService.RemoveAsync(entity);
            return Ok();
        }
    }
}
