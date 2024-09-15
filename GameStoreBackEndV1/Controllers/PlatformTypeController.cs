using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.PlatformTypeService;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformTypeController : ControllerBase
    {
        private readonly IPlatformTypeService _platformTypeService;
        private readonly IMapper _mapper;

        public PlatformTypeController(IPlatformTypeService PlatformTypeService, IMapper mapper)
        {
            _platformTypeService = PlatformTypeService;
            _mapper = mapper;
        }

        [HttpGet("GetPlatformTypes")]
        public async Task<IActionResult> Get()
        {
            var res = await _platformTypeService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("GetPlatformType/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await _platformTypeService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpGet("GetPlatformType/{platformTypeName}")]
        public async Task<IActionResult> Get(string platformTypeName)
        {
            var res = await _platformTypeService.GetByNameAsync(platformTypeName);
            return Ok(res);
        }

        [HttpPost("CreatePlatformType")]
        public async Task<IActionResult> Post([FromBody] CreatePlatformTypeDto createPlatformType)
        {
            var res = await _platformTypeService.CreateAsync(createPlatformType);
            return Created("", res);
        }
    }
}
