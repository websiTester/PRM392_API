using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRM392_API.Models
{
    public class FCMToken
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Token { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? DeviceName { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public virtual User? User { get; set; }
    }
}
