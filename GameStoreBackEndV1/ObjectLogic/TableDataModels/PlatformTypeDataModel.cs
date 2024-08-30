using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("PlatformType")]
    public class PlatformTypeDataModel
    {
        [Required]
        [Key]
        public Guid PlatformTypeId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
