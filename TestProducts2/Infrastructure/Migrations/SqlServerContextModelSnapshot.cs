﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BenefitMarketSegment", b =>
                {
                    b.Property<int>("BenefitsId")
                        .HasColumnType("integer");

                    b.Property<int>("MarketSegmentsId")
                        .HasColumnType("integer");

                    b.HasKey("BenefitsId", "MarketSegmentsId");

                    b.HasIndex("MarketSegmentsId");

                    b.ToTable("BenefitMarketSegment");
                });

            modelBuilder.Entity("BenefitMini", b =>
                {
                    b.Property<int>("BenefitsId")
                        .HasColumnType("integer");

                    b.Property<int>("MinisId")
                        .HasColumnType("integer");

                    b.HasKey("BenefitsId", "MinisId");

                    b.HasIndex("MinisId");

                    b.ToTable("BenefitMini");
                });

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

            modelBuilder.Entity("Domain.Models.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("Domain.Models.BenefitDescription", b =>
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

            modelBuilder.Entity("Domain.Models.CategoryOfBenefit", b =>
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

                    b.ToTable("CategoryOfBenefits");
                });

            modelBuilder.Entity("Domain.Models.CategoryOfBenefitDescription", b =>
                {
                    b.Property<int>("CategoryOfBenefitId")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryOfBenefitId", "Language");

                    b.ToTable("CategoryOfBenefitDescription");
                });

            modelBuilder.Entity("Domain.Models.MarketSegment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UrlName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MarketSegments");
                });

            modelBuilder.Entity("Domain.Models.MarketSegmentDescription", b =>
                {
                    b.Property<int>("MarketSegmentId")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MarketSegmentId", "Language");

                    b.ToTable("MarketSegmentDescription");
                });

            modelBuilder.Entity("Domain.Models.Mini", b =>
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

                    b.ToTable("Minis");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
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

            modelBuilder.Entity("Domain.Models.Warranty", b =>
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

            modelBuilder.Entity("Domain.Models.WarrantyLength", b =>
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

            modelBuilder.Entity("Domain.Models.WarrantyLengthDescription", b =>
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

            modelBuilder.Entity("Domain.Models.WarrantyNotabene", b =>
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

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("WarrantyNotabenes");
                });

            modelBuilder.Entity("Domain.Models.WarrantyNotabeneDescription", b =>
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

            modelBuilder.Entity("Domain.Models.WarrantyTitle", b =>
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

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("WarrantyTitles");
                });

            modelBuilder.Entity("Domain.Models.WarrantyTitleDescription", b =>
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

            modelBuilder.Entity("BenefitMarketSegment", b =>
                {
                    b.HasOne("Domain.Models.Benefit", null)
                        .WithMany()
                        .HasForeignKey("BenefitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.MarketSegment", null)
                        .WithMany()
                        .HasForeignKey("MarketSegmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BenefitMini", b =>
                {
                    b.HasOne("Domain.Models.Benefit", null)
                        .WithMany()
                        .HasForeignKey("BenefitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Mini", null)
                        .WithMany()
                        .HasForeignKey("MinisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BenefitProduct", b =>
                {
                    b.HasOne("Domain.Models.Benefit", null)
                        .WithMany()
                        .HasForeignKey("BenefitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Benefit", b =>
                {
                    b.HasOne("Domain.Models.CategoryOfBenefit", "Category")
                        .WithMany("Benefits")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Models.BenefitDescription", b =>
                {
                    b.HasOne("Domain.Models.Benefit", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.CategoryOfBenefitDescription", b =>
                {
                    b.HasOne("Domain.Models.CategoryOfBenefit", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("CategoryOfBenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.MarketSegmentDescription", b =>
                {
                    b.HasOne("Domain.Models.MarketSegment", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("MarketSegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Warranty", b =>
                {
                    b.HasOne("Domain.Models.WarrantyLength", "WarrantyLength")
                        .WithMany()
                        .HasForeignKey("WarrantyLengthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.WarrantyNotabene", "WarrantyNotabene")
                        .WithMany()
                        .HasForeignKey("WarrantyNotabeneId");

                    b.HasOne("Domain.Models.WarrantyTitle", "WarrantyTitle")
                        .WithMany()
                        .HasForeignKey("WarrantyTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WarrantyLength");

                    b.Navigation("WarrantyNotabene");

                    b.Navigation("WarrantyTitle");
                });

            modelBuilder.Entity("Domain.Models.WarrantyLengthDescription", b =>
                {
                    b.HasOne("Domain.Models.WarrantyLength", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("WarrantyLengthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.WarrantyNotabeneDescription", b =>
                {
                    b.HasOne("Domain.Models.WarrantyNotabene", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("WarrantyNotabeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.WarrantyTitleDescription", b =>
                {
                    b.HasOne("Domain.Models.WarrantyTitle", null)
                        .WithMany("Descriptions")
                        .HasForeignKey("WarrantyTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductWarranty", b =>
                {
                    b.HasOne("Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Warranty", null)
                        .WithMany()
                        .HasForeignKey("WarrantiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Benefit", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("Domain.Models.CategoryOfBenefit", b =>
                {
                    b.Navigation("Benefits");

                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("Domain.Models.MarketSegment", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("Domain.Models.WarrantyLength", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("Domain.Models.WarrantyNotabene", b =>
                {
                    b.Navigation("Descriptions");
                });

            modelBuilder.Entity("Domain.Models.WarrantyTitle", b =>
                {
                    b.Navigation("Descriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
