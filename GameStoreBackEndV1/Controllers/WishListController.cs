using GameStoreBackEndV1.DataLogic.WishList;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.WishListService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpGet("GetWishLists")]
        public async Task<IActionResult> Get()
        {
            var res = await _wishListService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("GetByGameId/{id:guid}")]
        public async Task<IActionResult> GetByGameIdAsync(Guid id)
        {
            var res = await _wishListService.GetByGameIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByPlayerId/{id:guid}")]
        public async Task<IActionResult> GetByPlayerIdAsync(Guid id)
        {
            var res = await _wishListService.GetByPlayerIdAsync(id);
            return Ok(res);
        }

        [HttpPut("AddToWishList")]
        public async Task<IActionResult> Put(CreateWishListDto entity)
        {
            var res = await _wishListService.UpdateAsync(entity);
            return Created("", res);
        }

        [HttpDelete("RemoveFromWishList")]
        public async Task<IActionResult> Delete(CreateWishListDto entity)
        {
            await _wishListService.RemoveAsync(entity);
            return Ok();
        }
    }
}
