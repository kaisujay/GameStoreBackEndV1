using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("WishList")]
    public class WishListDataModel
    {
        public Guid WishListId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public PlayerTableDataModel Player { get; set; }

        public GameDataModel Game { get; set; }
    }
}
