using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("OrderHistory")]
    public class OrderHistoryDataModel
    {
        [Key]
        public Guid OrderHistoryId { get; set; }

        public Guid OrderId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public PlayerTableDataModel Player { get; set; }

        public GameDataModel Game { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public float PurchaseAmmount { get; set; }
    }
}
