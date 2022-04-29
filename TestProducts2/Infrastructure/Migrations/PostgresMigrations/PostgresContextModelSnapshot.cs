﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations.PostgresMigrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.ColorName", b =>
                {
                    b.Property<string>("ProductType")
                        .HasColumnType("text");

                    b.Property<string>("ColorCode")
                        .HasColumnType("text");

                    b.Property<string>("StyleCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductType", "ColorCode");

                    b.ToTable("ColorNames");
                });
#pragma warning restore 612, 618
        }
    }
}
