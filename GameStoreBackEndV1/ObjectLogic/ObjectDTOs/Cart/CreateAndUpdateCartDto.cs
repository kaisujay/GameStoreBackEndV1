using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreateAndUpdateCartDto
    {
        [Required(ErrorMessage = "PlayerId is required")]
        public Guid? PlayerId { get; set; }


        [Required(ErrorMessage = "GameId is required")]
        public List<Guid> GameId { get; set; }

    }
}
