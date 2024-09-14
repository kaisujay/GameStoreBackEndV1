using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreatePlayerRoleDto
    {
        [Required(ErrorMessage = "Player Email is required")]
        public string PlayerEmail { get; set; }


        [Required(ErrorMessage = "Role Name is required")]
        public string RoleName { get; set; }
    }
}
