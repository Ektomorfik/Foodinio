﻿// <auto-generated />
using Foodinio.Core.Domain;
using Foodinio.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Foodinio.Web.Migrations
{
    [DbContext(typeof(FoodinioContext))]
    [Migration("20171222084915_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Foodinio.Core.Domain.BlanketOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BlanketOrders");
                });

            modelBuilder.Entity("Foodinio.Core.Domain.DeliveryAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("HouseNumber");

                    b.Property<Guid?>("OrderId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("DeliveryAddresses");
                });

            modelBuilder.Entity("Foodinio.Core.Domain.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BlanketOrderId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<int>("MealType");

                    b.Property<string>("Name");

                    b.Property<string>("PicturePath");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("BlanketOrderId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Foodinio.Core.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BlanketOrderId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<decimal>("TotalPrice");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BlanketOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Foodinio.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Salt");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Foodinio.Core.Domain.BlanketOrder", b =>
                {
                    b.HasOne("Foodinio.Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Foodinio.Core.Domain.DeliveryAddress", b =>
                {
                    b.HasOne("Foodinio.Core.Domain.Order", "Order")
                        .WithOne("DeliveryAddress")
                        .HasForeignKey("Foodinio.Core.Domain.DeliveryAddress", "OrderId");

                    b.HasOne("Foodinio.Core.Domain.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Foodinio.Core.Domain.Dish", b =>
                {
                    b.HasOne("Foodinio.Core.Domain.BlanketOrder")
                        .WithMany("Dishes")
                        .HasForeignKey("BlanketOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Foodinio.Core.Domain.Order", b =>
                {
                    b.HasOne("Foodinio.Core.Domain.BlanketOrder", "BlanketOrder")
                        .WithMany()
                        .HasForeignKey("BlanketOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Foodinio.Core.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
