using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("Cart")]
    public class CartDataModel
    {
        public Guid CartId { get; set; }

        public Guid? PlayerId { get; set; }

        public List<Guid> GameId { get; set; }

        public PlayerTableDataModel? Player { get; set; }

        public List<GameDataModel> Games { get; set; }
    }
}
