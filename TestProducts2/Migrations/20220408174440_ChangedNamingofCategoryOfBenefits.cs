using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestProducts2.Migrations
{
    public partial class ChangedNamingofCategoryOfBenefits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_OfBenefitsCategories_CategoryId",
                table: "Benefits");

            migrationBuilder.DropTable(
                name: "OfBenefitsCategoryDescription");

            migrationBuilder.DropTable(
                name: "OfBenefitsCategories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Benefits",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CategoryOfBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOfBenefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryOfBenefitDescription",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CategoryOfBenefitId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOfBenefitDescription", x => new { x.CategoryId, x.Language });
                    table.ForeignKey(
                        name: "FK_CategoryOfBenefitDescription_CategoryOfBenefits_CategoryOfB~",
                        column: x => x.CategoryOfBenefitId,
                        principalTable: "CategoryOfBenefits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfBenefitDescription_CategoryOfBenefitId",
                table: "CategoryOfBenefitDescription",
                column: "CategoryOfBenefitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_CategoryOfBenefits_CategoryId",
                table: "Benefits",
                column: "CategoryId",
                principalTable: "CategoryOfBenefits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_CategoryOfBenefits_CategoryId",
                table: "Benefits");

            migrationBuilder.DropTable(
                name: "CategoryOfBenefitDescription");

            migrationBuilder.DropTable(
                name: "CategoryOfBenefits");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Benefits",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OfBenefitsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfBenefitsCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfBenefitsCategoryDescription",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    OfBenefitsCategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfBenefitsCategoryDescription", x => new { x.CategoryId, x.Language });
                    table.ForeignKey(
                        name: "FK_OfBenefitsCategoryDescription_OfBenefitsCategories_OfBenefi~",
                        column: x => x.OfBenefitsCategoryId,
                        principalTable: "OfBenefitsCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfBenefitsCategoryDescription_OfBenefitsCategoryId",
                table: "OfBenefitsCategoryDescription",
                column: "OfBenefitsCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_OfBenefitsCategories_CategoryId",
                table: "Benefits",
                column: "CategoryId",
                principalTable: "OfBenefitsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
