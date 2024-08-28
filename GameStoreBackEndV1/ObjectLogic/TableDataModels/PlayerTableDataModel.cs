using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    [Table("Player")]
    public class PlayerTableDataModel
    {
        [Required]
        [Key]
        public Guid PlayerId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "Varchar")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(13)]
        public string Phone { get; set; }

        [Column("WalletBalance")]
        public float Wallet { get; set; } = 0.0f;

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
