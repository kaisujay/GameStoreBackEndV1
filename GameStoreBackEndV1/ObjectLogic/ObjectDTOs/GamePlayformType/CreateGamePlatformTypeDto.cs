using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreateGamePlatformTypeDto
    {
        [Required(ErrorMessage = "GameId is required")]
        public Guid GameId { get; set; }


        [Required(ErrorMessage = "PlatformTypeId is required")]
        public Guid PlatformTypeId { get; set; }
    }
}
