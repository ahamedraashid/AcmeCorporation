using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorporation.API.Data.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime UpdatedTime { get; set; }
    }
}