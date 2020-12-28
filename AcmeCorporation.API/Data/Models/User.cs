using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AcmeCorporation.API.Shared.Enums;

namespace AcmeCorporation.API.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        public int? ContactNumber { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        public Role Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}