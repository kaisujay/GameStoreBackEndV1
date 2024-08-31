using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "RoleId is required")]
        public Guid RoleId { get; set; }


        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
    }
}
