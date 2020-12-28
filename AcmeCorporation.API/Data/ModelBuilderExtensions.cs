using System;
using System.Collections.Generic;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorporation.API.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            byte[] passwordHash, passwordSalt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("password123"));
            }

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress).IsUnique();
                entity.HasData(new User()
                {
                    UserId = 102,
                    Username = "John Wick",
                    EmailAddress = "johnwick@gmail.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = Role.Admin
                },
                 new User()
                 {
                     UserId = 101,
                     Username = "Peter Park",
                     EmailAddress = "paterpark@gmail.com",
                     PasswordHash = passwordHash,
                     PasswordSalt = passwordSalt,
                     Role = Role.User
                 },
               new User()
               {
                   UserId = 100,
                   Username = "Jason Statham",
                   EmailAddress = "jason@gmail.com",
                   PasswordHash = passwordHash,
                   PasswordSalt = passwordSalt,
                   Role = Role.User
               });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasData(new Product()
                {
                    Id = 100,
                    Description = "OnePlus 8 Pro Original, Sealed pack, Global Version, 1 Year Software Warranty Easy payment scheme available for upto 36 months for Credit card holders* • 6.78 inches 3168 x 1440 pixels 513 ppi AMOLED Display • OxygenOS based on Android™ 10",
                    Name = "ONEPLUS 8 PRO BRANDNEW 12GB RAM 256GB",
                    StartingTime = DateTime.Now,
                    EndingTime = DateTime.Now.AddDays(3),
                    InitialBid = 100000,
                    IsDeleted = false,
                    Status = ProductStatus.Active
                },
                 new Product()
                 {
                     Id = 101,
                     Description = "Brand New Condition Samsung Galaxy Note 20 Ultra 256/12GB/ Mystic Bronze/ Softlogic Company Warranty Real Pictures of The Device Attached",
                     Name = "Samsung Galaxy Note 20 Ultra 256GB (Used) 12GB",
                     StartingTime = DateTime.Now,
                     EndingTime = DateTime.Now.AddDays(1),
                     InitialBid = 80000,
                     IsDeleted = false,
                     Status = ProductStatus.Active
                 },
               new Product()
               {
                   Id = 102,
                   Description = "100% condition Usa phone Complete set box available 90% battery health No errors at all 3u tool report",
                   Name = "Iphone XS Max 128GB (Brandew condition)",
                   StartingTime = DateTime.Now.AddDays(1),
                   EndingTime = DateTime.Now.AddDays(4),
                   InitialBid = 120000,
                   IsDeleted = false,
                   Status = ProductStatus.Active
               });
            });

            modelBuilder.Entity<Photo>(entity =>
           {
               entity.HasData(
                new Photo()
                {
                    Filename = "Images/3e80db70-f5cc-45b9-b3d8-524d562e1709.jpg",
                    Id = 100,
                    ProductId = 100
                },
                new Photo()
                {
                    Filename = "Images/494d2306-f579-46ad-82d2-44f69347db03.jpg",
                    Id = 101,
                    ProductId = 100
                },
                new Photo()
                {
                    Filename = "Images/0576cdc7-5aed-4aa4-9bd2-6fdf63cacd23.jpg",
                    Id = 102,
                    ProductId = 100
                },
                new Photo()
                {
                    Filename = "Images/4bd66dfa-8e71-4e80-973a-1410261d73b7.jpg",
                    Id = 103,
                    ProductId = 101
                },
                new Photo()
                {
                    Filename = "Images/5dab2566-0fce-4529-877a-06be0282e5e0.jpg",
                    Id = 104,
                    ProductId = 101
                },
                new Photo()
                {
                    Filename = "Images/57fd5160-7dea-4c2f-b92c-5b76d73ef8c7.jpg",
                    Id = 105,
                    ProductId = 101
                },
                new Photo()
                {
                    Filename = "Images/c6eba157-1f8e-4217-a469-a19c4976bb4c.jpg",
                    Id = 110,
                    ProductId = 102
                },
                new Photo()
                {
                    Filename = "Images/cc0ab8d6-b9b9-44b2-90e1-f04cb339d1aa.jpg",
                    Id = 111,
                    ProductId = 102
                }
            );
           });
        }
    }
}