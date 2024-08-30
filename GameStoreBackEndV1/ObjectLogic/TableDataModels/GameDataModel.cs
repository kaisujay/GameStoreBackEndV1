using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("Game")]
    public class GameDataModel
    {
        [Required]
        [Key]
        public Guid GameId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string GameDetails { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [Range(0,100)]  // Discount Range from 0% to 100%
        public byte DiscountPercent { get; set; }

    }
}
