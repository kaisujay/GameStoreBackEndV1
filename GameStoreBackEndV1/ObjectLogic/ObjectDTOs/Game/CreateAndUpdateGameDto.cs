using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreateAndUpdateGameDto
    {
        [Required(ErrorMessage = "Game Name is required")]
        [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters", MinimumLength = 1)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Game Details is required")]
        public string GameDetails { get; set; }


        [Required(ErrorMessage = "Game Price is required")]
        public float Price { get; set; }


        public byte DiscountPercent { get; set; } = 0;
    }
}
