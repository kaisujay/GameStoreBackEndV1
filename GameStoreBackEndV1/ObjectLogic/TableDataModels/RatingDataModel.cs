using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("Rating")]
    public class RatingDataModel
    {
        [Required]
        [Key]
        public Guid RatingId { get; set; }

        public string? Comment { get; set; }

        [Range(0,5)]
        public byte Star { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public PlayerTableDataModel Player { get; set; }

        public GameDataModel Game { get; set; }
    }
}
