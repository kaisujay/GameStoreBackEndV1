using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.CartService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("GetCarts")]
        public async Task<IActionResult> Get()
        {
            var res = await _cartService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var res = await _cartService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByPlayerId/{id:guid}")]
        public async Task<IActionResult> GetByPlayerIdAsync(Guid id)
        {
            var res = await _cartService.GetByPlayerIdAsync(id);
            return Ok(res);
        }

        [HttpPut("AddToCart")]
        public async Task<IActionResult> Put(CreateAndUpdateCartDto entity)
        {
            var res = await _cartService.UpdateAsync(entity);
            return Created("", res);
        }

        [HttpDelete("RemoveFromCart")]
        public async Task<IActionResult> Delete(CreateAndUpdateCartDto entity)
        {
            await _cartService.RemoveAsync(entity);
            return Ok();
        }
    }
}
