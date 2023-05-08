﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using solvex_dominicana.Context;

#nullable disable

namespace solvex_dominicana.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230508045258_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("solvex_dominicana.Models.BrandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("solvex_dominicana.Models.BrandProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BrandId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductId");

                    b.ToTable("brand-products");
                });

            modelBuilder.Entity("solvex_dominicana.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("solvex_dominicana.Models.SuperMarketBrandModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("SuperMarketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("SuperMarketId");

                    b.ToTable("super-market-brands");
                });

            modelBuilder.Entity("solvex_dominicana.Models.SuperMarketModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("super-markets");
                });

            modelBuilder.Entity("solvex_dominicana.Models.BrandProductModel", b =>
                {
                    b.HasOne("solvex_dominicana.Models.BrandModel", "Brand")
                        .WithMany("BrandProducts")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("solvex_dominicana.Models.ProductModel", "Product")
                        .WithMany("BrandProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("solvex_dominicana.Models.SuperMarketBrandModel", b =>
                {
                    b.HasOne("solvex_dominicana.Models.BrandModel", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("solvex_dominicana.Models.SuperMarketModel", "SuperMarket")
                        .WithMany()
                        .HasForeignKey("SuperMarketId");

                    b.Navigation("Brand");

                    b.Navigation("SuperMarket");
                });

            modelBuilder.Entity("solvex_dominicana.Models.BrandModel", b =>
                {
                    b.Navigation("BrandProducts");
                });

            modelBuilder.Entity("solvex_dominicana.Models.ProductModel", b =>
                {
                    b.Navigation("BrandProducts");
                });
#pragma warning restore 612, 618
        }
    }
}