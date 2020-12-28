using System.ComponentModel.DataAnnotations;

namespace AcmeCorporation.API.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Filename { get; set; }
        public int ProductId { get; set; }
        public Product Product{ get; set; }
    }
}