﻿// <auto-generated />
using FireTruckFinder.Data;
using FireTruckFinder.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FireTruckFinder.Web.Data.Migrations
{
    [DbContext(typeof(FireTruckFinderDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FireTruckFinder.Data.Models.FirePump", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Efficiency");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Power");

                    b.HasKey("Id");

                    b.ToTable("FirePumps");
                });

            modelBuilder.Entity("FireTruckFinder.Data.Models.FireTruck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Price");

                    b.Property<DateTime>("ProduceDate");

                    b.Property<int>("PumpId");

                    b.Property<int>("SaleId");

                    b.Property<int>("WatertankCapacity");

                    b.HasKey("Id");

                    b.HasIndex("PumpId");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("FireTrucks");
                });

            modelBuilder.Entity("FireTruckFinder.Data.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FireTruckId");

                    b.Property<string>("SellerId");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("FireTruckFinder.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Age");

                    b.Property<DateTime>("Birtdate");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("FireTruckFinder.Data.Models.FireTruck", b =>
                {
                    b.HasOne("FireTruckFinder.Data.Models.FirePump", "Pump")
                        .WithMany("Firetrucks")
                        .HasForeignKey("PumpId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FireTruckFinder.Data.Models.Sale", "Sale")
                        .WithOne("FireTruck")
                        .HasForeignKey("FireTruckFinder.Data.Models.FireTruck", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FireTruckFinder.Data.Models.Sale", b =>
                {
                    b.HasOne("FireTruckFinder.Data.Models.User", "Seller")
                        .WithMany("Sales")
                        .HasForeignKey("SellerId");
                });
#pragma warning restore 612, 618
        }
    }
}
