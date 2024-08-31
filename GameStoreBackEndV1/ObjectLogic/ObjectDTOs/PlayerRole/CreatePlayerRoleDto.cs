using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreatePlayerRoleDto
    {
        [Required(ErrorMessage = "PlayerRoleId is required")]
        public Guid PlayerRoleId { get; set; }


        [Required(ErrorMessage = "PlayerId is required")]
        public Guid PlayerId { get; set; }


        [Required(ErrorMessage = "RoleId is required")]
        public Guid RoleId { get; set; }
    }
}
