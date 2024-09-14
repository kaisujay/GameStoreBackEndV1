using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
    }
}
