using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AcmeCorporation.API.Shared.Enums;

namespace AcmeCorporation.API.Data.Models
{
    public class Product
    {
        public Product()
        {
            Photos = new Collection<Photo>();
            Transactions = new Collection<Transaction>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Photo> Photos { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InitialBid { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime StartingTime { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime EndingTime { get; set; }

        [NotMapped]
        public decimal HighestBid
        {
            get
            {
                if (Transactions.Any())
                {
                    return Transactions.Select(t => t.Amount).Max();
                }
                return InitialBid;
            }
        }

    }
}