using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("GamePlatformType")]
    public class GamePlatformTypeDataModel
    {
        public Guid GameId { get; set; }

        public Guid PlatformTypeId { get; set; }
        
        public GameDataModel Game { get; set; }
        
        public PlatformTypeDataModel PlatformType { get; set; }
    }
}
