using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CreatePlatformTypeDto
    {
        [Required(ErrorMessage = "PlatformTypeId is required")]
        public Guid PlatformTypeId { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
