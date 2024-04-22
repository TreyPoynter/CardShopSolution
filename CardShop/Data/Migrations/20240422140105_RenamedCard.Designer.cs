﻿// <auto-generated />
using System;
using CardShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CardShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240422140105_RenamedCard")]
    partial class RenamedCard
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CardShop.Models.Domain.CardType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("CardTypes");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            Name = "Base"
                        },
                        new
                        {
                            TypeId = 2,
                            Name = "Rookie"
                        },
                        new
                        {
                            TypeId = 3,
                            Name = "Insert"
                        },
                        new
                        {
                            TypeId = 4,
                            Name = "Autograph"
                        },
                        new
                        {
                            TypeId = 5,
                            Name = "Relic"
                        },
                        new
                        {
                            TypeId = 6,
                            Name = "Parallel"
                        },
                        new
                        {
                            TypeId = 7,
                            Name = "Memorabillia"
                        },
                        new
                        {
                            TypeId = 8,
                            Name = "Promotional"
                        },
                        new
                        {
                            TypeId = 9,
                            Name = "Chase"
                        },
                        new
                        {
                            TypeId = 10,
                            Name = "Box Topper"
                        });
                });

            modelBuilder.Entity("CardShop.Models.Domain.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            ManufacturerId = 1,
                            Name = "Topps"
                        },
                        new
                        {
                            ManufacturerId = 2,
                            Name = "Panini"
                        },
                        new
                        {
                            ManufacturerId = 3,
                            Name = "Upper Deck"
                        },
                        new
                        {
                            ManufacturerId = 4,
                            Name = "Bowman"
                        },
                        new
                        {
                            ManufacturerId = 5,
                            Name = "Leaf Trading Cards"
                        },
                        new
                        {
                            ManufacturerId = 6,
                            Name = "Donruss"
                        },
                        new
                        {
                            ManufacturerId = 7,
                            Name = "Score"
                        },
                        new
                        {
                            ManufacturerId = 8,
                            Name = "Fleer"
                        },
                        new
                        {
                            ManufacturerId = 9,
                            Name = "Pro Set"
                        },
                        new
                        {
                            ManufacturerId = 10,
                            Name = "Tristar"
                        });
                });

            modelBuilder.Entity("CardShop.Models.Domain.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"));

                    b.Property<int>("CardId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PurchaseId");

                    b.HasIndex("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CardShop.Models.Domain.Quality", b =>
                {
                    b.Property<int>("QualityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QualityId"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QualityId");

                    b.ToTable("Qualities");

                    b.HasData(
                        new
                        {
                            QualityId = 1,
                            Type = "Mint"
                        },
                        new
                        {
                            QualityId = 2,
                            Type = "Near Mint"
                        },
                        new
                        {
                            QualityId = 3,
                            Type = "Excellent"
                        },
                        new
                        {
                            QualityId = 4,
                            Type = "Very Good"
                        },
                        new
                        {
                            QualityId = 5,
                            Type = "Good"
                        },
                        new
                        {
                            QualityId = 6,
                            Type = "Fair"
                        },
                        new
                        {
                            QualityId = 7,
                            Type = "Poor"
                        },
                        new
                        {
                            QualityId = 8,
                            Type = "Damaged"
                        });
                });

            modelBuilder.Entity("CardShop.Models.Domain.Sport", b =>
                {
                    b.Property<int>("SportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SportId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportId");

                    b.ToTable("Sports");

                    b.HasData(
                        new
                        {
                            SportId = 1,
                            Name = "Baseball"
                        },
                        new
                        {
                            SportId = 2,
                            Name = "Football"
                        },
                        new
                        {
                            SportId = 3,
                            Name = "Hockey"
                        },
                        new
                        {
                            SportId = 4,
                            Name = "Golf"
                        },
                        new
                        {
                            SportId = 5,
                            Name = "Wrestling"
                        },
                        new
                        {
                            SportId = 6,
                            Name = "Racing"
                        },
                        new
                        {
                            SportId = 7,
                            Name = "Boxing"
                        },
                        new
                        {
                            SportId = 8,
                            Name = "MMA"
                        });
                });

            modelBuilder.Entity("CardShop.Models.Domain.TradingCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsForSale")
                        .HasColumnType("bit");

                    b.Property<int?>("ManufactuererId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<long>("Number")
                        .HasColumnType("bigint");

                    b.Property<string>("Player")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QualityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SportId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TypeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<short?>("Year")
                        .IsRequired()
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("ManufactuererId");

                    b.HasIndex("QualityId");

                    b.HasIndex("SportId");

                    b.HasIndex("TypeId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("CardShop.Models.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CardShop.Models.Domain.Purchase", b =>
                {
                    b.HasOne("CardShop.Models.Domain.TradingCard", "CardBought")
                        .WithMany("Purchases")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardShop.Models.Domain.User", "Buyer")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId");

                    b.Navigation("Buyer");

                    b.Navigation("CardBought");
                });

            modelBuilder.Entity("CardShop.Models.Domain.TradingCard", b =>
                {
                    b.HasOne("CardShop.Models.Domain.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufactuererId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardShop.Models.Domain.Quality", "Quality")
                        .WithMany()
                        .HasForeignKey("QualityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardShop.Models.Domain.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardShop.Models.Domain.CardType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");

                    b.Navigation("Quality");

                    b.Navigation("Sport");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CardShop.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CardShop.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CardShop.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CardShop.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CardShop.Models.Domain.TradingCard", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("CardShop.Models.Domain.User", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
