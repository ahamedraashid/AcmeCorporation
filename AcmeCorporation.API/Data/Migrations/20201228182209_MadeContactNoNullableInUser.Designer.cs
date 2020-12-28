﻿// <auto-generated />
using System;
using AcmeCorporation.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcmeCorporation.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201228182209_MadeContactNoNullableInUser")]
    partial class MadeContactNoNullableInUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcmeCorporation.API.Data.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("AcmeCorporation.API.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndingTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InitialBid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AcmeCorporation.API.Data.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId");

                    b.Property<DateTime>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId");

                    b.HasKey("TransactionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AcmeCorporation.API.Data.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(255);

                    b.Property<int?>("ContactNumber");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<int>("Role");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AcmeCorporation.API.Data.Models.Photo", b =>
                {
                    b.HasOne("AcmeCorporation.API.Data.Models.Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("AcmeCorporation.API.Data.Models.Transaction", b =>
                {
                    b.HasOne("AcmeCorporation.API.Data.Models.Product", "Product")
                        .WithMany("Transactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcmeCorporation.API.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
