using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("Role")]
    public class RoleTableDataModel
    {
        [Required]
        [Key]
        public Guid RoleId { get; set; }

        [Required]
        [MaxLength(15)]
        public string RoleName { get; set; }
    }
}
