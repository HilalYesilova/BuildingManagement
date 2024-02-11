﻿// <auto-generated />
using System;
using BuildingManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuildingManagement.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240211145613_deleteTrigger")]
    partial class deleteTrigger
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentNumber")
                        .HasColumnType("int");

                    b.Property<string>("ApartmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlockInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<bool>("OccupancyStatus")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerOrTenant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.ApartmentBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<decimal>("ElectricityAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GasAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WaterAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("ApartmentBills");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<decimal>("ElectricityAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GasAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Month")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("WaterAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Dues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Dues");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ApartmentBillId")
                        .HasColumnType("int");

                    b.Property<int?>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("ApartmentId1")
                        .HasColumnType("int");

                    b.Property<int?>("DuesId")
                        .HasColumnType("int");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentBillId");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("ApartmentId1");

                    b.HasIndex("DuesId")
                        .IsUnique()
                        .HasFilter("[DuesId] IS NOT NULL");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("BuildingManagement.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BuildingManagement.Entity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Apartment", b =>
                {
                    b.HasOne("BuildingManagement.Entity.Entities.Building", "Building")
                        .WithMany("Apartments")
                        .HasForeignKey("BuildingId");

                    b.HasOne("BuildingManagement.Entity.User", "User")
                        .WithOne("Apartment")
                        .HasForeignKey("BuildingManagement.Entity.Entities.Apartment", "UserId");

                    b.Navigation("Building");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.ApartmentBill", b =>
                {
                    b.HasOne("BuildingManagement.Entity.Entities.Apartment", "Apartment")
                        .WithMany("ApartmentBills")
                        .HasForeignKey("ApartmentId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Bill", b =>
                {
                    b.HasOne("BuildingManagement.Entity.Entities.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Dues", b =>
                {
                    b.HasOne("BuildingManagement.Entity.Entities.Apartment", "Apartment")
                        .WithMany("Dues")
                        .HasForeignKey("ApartmentId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Payment", b =>
                {
                    b.HasOne("BuildingManagement.Entity.Entities.ApartmentBill", "ApartmentBill")
                        .WithMany()
                        .HasForeignKey("ApartmentBillId");

                    b.HasOne("BuildingManagement.Entity.Entities.Apartment", "Apartment")
                        .WithMany()
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BuildingManagement.Entity.Entities.Apartment", null)
                        .WithMany("Payments")
                        .HasForeignKey("ApartmentId1");

                    b.HasOne("BuildingManagement.Entity.Entities.Dues", "Dues")
                        .WithOne()
                        .HasForeignKey("BuildingManagement.Entity.Entities.Payment", "DuesId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BuildingManagement.Entity.Entities.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId");

                    b.Navigation("Apartment");

                    b.Navigation("ApartmentBill");

                    b.Navigation("Dues");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BuildingManagement.Entity.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BuildingManagement.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BuildingManagement.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("BuildingManagement.Entity.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagement.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BuildingManagement.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Apartment", b =>
                {
                    b.Navigation("ApartmentBills");

                    b.Navigation("Dues");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("BuildingManagement.Entity.Entities.Building", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("BuildingManagement.Entity.User", b =>
                {
                    b.Navigation("Apartment");
                });
#pragma warning restore 612, 618
        }
    }
}
