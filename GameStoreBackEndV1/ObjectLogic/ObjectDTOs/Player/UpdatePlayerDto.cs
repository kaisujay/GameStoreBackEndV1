using System.ComponentModel.DataAnnotations;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class UpdatePlayerDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(25, ErrorMessage = "Must be between 1 and 25 characters", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(25, ErrorMessage = "Must be between 1 and 25 characters", MinimumLength = 1)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "User Name is required")]
        [StringLength(20, ErrorMessage = "Must be between 1 and 20 characters", MinimumLength = 1)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [StringLength(20, ErrorMessage = "Must be between 1 and 20 characters", MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone is required")]
        [StringLength(13, ErrorMessage = "Must be between 10 and 13 characters", MinimumLength = 10)]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Date Of Birth is required")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [StringLength(15, ErrorMessage = "Must be between 1 and 15 characters", MinimumLength = 1)]
        public string Country { get; set; }
    }
}
