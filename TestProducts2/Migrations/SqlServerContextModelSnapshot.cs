﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestProducts2.Data;

#nullable disable

namespace TestProducts2.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.1.22076.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BenefitProduct", b =>
                {
                    b.Property<int>("BenefitsId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("BenefitsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("BenefitProduct");
                });

            modelBuilder.Entity("ProductWarranty", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.Property<int>("WarrantiesId")
                        .HasColumnType("integer");

                    b.HasKey("ProductsId", "WarrantiesId");

                    b.HasIndex("WarrantiesId");

                    b.ToTable("ProductWarranty");
                });

            modelBuilder.Entity("TestProducts2.Models.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("TestProducts2.Models.BenefitDescription", b =>
                {
                    b.Property<int>("BenefitId")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BenefitId", "Language");

                    b.ToTable("BenefitDescription");
                });

            modelBuilder.Entity("TestProducts2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StyleCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StyleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TestProducts2.Models.Warranty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("WarrantyLengthId")
                        .HasColumnType("integer");

                    b.Property<int?>("WarrantyNotabeneId")
                        .HasColumnType("integer");

                    b.Property<int>("WarrantyTitleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WarrantyLengthId");

                    b.HasIndex("WarrantyNotabeneId");

                    b.HasIndex("WarrantyTitleId");

                    b.ToTable("Warranties");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyLength", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("WarrantyLengths");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyLengthDescription", b =>
                {
                    b.Property<int>("WarrantyLengthId")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("WarrantyLengthId", "Language");

                    b.ToTable("WarrantyLengthDescription");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyNotabene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("WarrantyNotabenes");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyNotabeneDescription", b =>
                {
                    b.Property<int>("WarrantyNotabeneId")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("WarrantyNotabeneId", "Language");

                    b.ToTable("WarrantyNotabeneDescription");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("WarrantyTitles");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyTitleDescription", b =>
                {
                    b.Property<int>("WarrantyTitleId")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("WarrantyTitleId", "Language");

                    b.ToTable("WarrantyTitleDescription");
                });

            modelBuilder.Entity("BenefitProduct", b =>
                {
                    b.HasOne("TestProducts2.Models.Benefit", null)
                        .WithMany()
                        .HasForeignKey("BenefitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProducts2.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductWarranty", b =>
                {
                    b.HasOne("TestProducts2.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProducts2.Models.Warranty", null)
                        .WithMany()
                        .HasForeignKey("WarrantiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestProducts2.Models.BenefitDescription", b =>
                {
                    b.HasOne("TestProducts2.Models.Benefit", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestProducts2.Models.Warranty", b =>
                {
                    b.HasOne("TestProducts2.Models.WarrantyLength", "WarrantyLength")
                        .WithMany()
                        .HasForeignKey("WarrantyLengthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProducts2.Models.WarrantyNotabene", "WarrantyNotabene")
                        .WithMany()
                        .HasForeignKey("WarrantyNotabeneId");

                    b.HasOne("TestProducts2.Models.WarrantyTitle", "WarrantyTitle")
                        .WithMany()
                        .HasForeignKey("WarrantyTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WarrantyLength");

                    b.Navigation("WarrantyNotabene");

                    b.Navigation("WarrantyTitle");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyLengthDescription", b =>
                {
                    b.HasOne("TestProducts2.Models.WarrantyLength", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("WarrantyLengthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyNotabeneDescription", b =>
                {
                    b.HasOne("TestProducts2.Models.WarrantyNotabene", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("WarrantyNotabeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyTitleDescription", b =>
                {
                    b.HasOne("TestProducts2.Models.WarrantyTitle", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("WarrantyTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestProducts2.Models.Benefit", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyLength", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyNotabene", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("TestProducts2.Models.WarrantyTitle", b =>
                {
                    b.Navigation("Descriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
