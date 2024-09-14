using AutoMapper;
using GameStoreBackEndV1.DataLogic.Role;
using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using GameStoreBackEndV1.ServiceLogic.ExceptionService;

namespace GameStoreBackEndV1.ServiceLogic.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IList<DisplayRoleDto>> GetAllAsync()
        {
            var result = await _roleRepository.GetAllAsync();
            var mappedResult = _mapper.Map<IList<DisplayRoleDto>>(result);

            return mappedResult;
        }

        public async Task<DisplayRoleDto> GetByIdAsync(Guid id)
        {
            var result = await _roleRepository.GetByIdAsync(id);
            var mappedResult = _mapper.Map<DisplayRoleDto>(result);

            return mappedResult;
        }

        public async Task<Guid> CreateAsync(CreateRoleDto entity)
        {
            var allCurrentRoles = await _roleRepository.GetAllAsync();
            var isRoleExists = allCurrentRoles.Where(x => x.RoleName.ToLower() == entity.RoleName.ToLower()).SingleOrDefault();

            if (isRoleExists != null)
            {
                throw new DataAlreadyExistsException("Role already exists");
            }

            var roleId = Guid.NewGuid();
            var mappedRole = _mapper.Map<RoleDto>(entity);

            mappedRole.RoleId = roleId;
            mappedRole.RoleName = entity.RoleName.ToLower();

            var newCreatedGuid = await _roleRepository.CreateAsync(mappedRole);

            return newCreatedGuid;
        }
    }
}
