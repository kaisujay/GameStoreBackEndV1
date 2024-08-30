using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("OrderHistory")]
    public class OrderHistoryDataModel
    {
        public Guid OrderHistoryId { get; set; }

        public Guid PlayerId { get; set; }

        public List<Guid> GameId { get; set; }

        public PlayerTableDataModel Player { get; set; }

        public List<GameDataModel> Games { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public float PurchaseAmmount { get; set; }
    }
}
