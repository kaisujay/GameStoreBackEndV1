using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreateRatingDto
    {
        [Required(ErrorMessage = "Comment is required")]
        public string? Comment { get; set; }


        [Required(ErrorMessage = "Star is required")]
        [Range(0, 5)]
        public byte Star { get; set; }


        [Required(ErrorMessage = "PlayerId is required")]
        public Guid PlayerId { get; set; }


        [Required(ErrorMessage = "GameId is required")]
        public Guid GameId { get; set; }
    }
}
