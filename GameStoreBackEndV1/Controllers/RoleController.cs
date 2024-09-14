using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.RoleService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEndV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> Get()
        {
            var res = await _roleService.GetAllAsync();
            return Ok(res);
        }

        [HttpGet("GetRole/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var res = await _roleService.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> Post([FromBody] CreateRoleDto createRole)
        {
            var res = await _roleService.CreateAsync(createRole);
            return Created("",res);
        }        
    }
}
