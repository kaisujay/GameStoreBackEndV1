using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("PlayerRole")]
    public class PlayerRoleTableDataModel
    {
        [Required]
        [Key]
        public Guid PlayerRoleId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid RoleId { get; set; }

        public PlayerTableDataModel Player { get; set; }    //After "Add-Migration" before "Undate-Migration" add onDelete: ReferentialAction.Restrict);

        public RoleTableDataModel Role { get; set; }    //After "Add-Migration" before "Undate-Migration" add onDelete: ReferentialAction.Restrict);
    }
}
