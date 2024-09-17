using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.OrderHistoryService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;

        public OrderHistoryController(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        [HttpGet("GetOrderHistorys")]
        public async Task<IActionResult> Get()
        {
            var res = await _orderHistoryService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var res = await _orderHistoryService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByPlayerId/{id:guid}")]
        public async Task<IActionResult> GetByPlayerIdAsync(Guid id)
        {
            var res = await _orderHistoryService.GetByPlayerIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByOrderId/{id:guid}")]
        public async Task<IActionResult> GetByOrderIdAsync(Guid id)
        {
            var res = await _orderHistoryService.GetByOrderIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetByDate/{dateTime:datetime}")]
        public async Task<IActionResult> GetByDateAsync(DateTime dateTime)
        {
            var res = await _orderHistoryService.GetByDateAsync(dateTime);
            return Ok(res);
        }

        [HttpPost("CreateOrderHistory")]
        public async Task<IActionResult> Post([FromBody] CreateOrderHistoryDto entity)
        {
            var res = await _orderHistoryService.CreateAsync(entity);
            return Created("", res);
        }
    }
}
