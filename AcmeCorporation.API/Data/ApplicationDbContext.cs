using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Services;
using AcmeCorporation.API.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
        // public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Seed();

            // builder.Entity<Product>()
            //     .HasMany(p => p.Transactions)
            //     .WithOne(t => t.Product)
            //     .HasForeignKey(t => t.ProductId);

            // builder.Entity<Transaction>()
            //     .HasOne(p => p.Product)
            //     .WithMany(s => s.Transactions)
            //     .HasForeignKey(t => t.ProductId);
        }
    }
}