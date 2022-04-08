using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestProducts2.Migrations
{
    public partial class NewNamingForOfBenefitsCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BenefitMarketSegment_MarketSegment_MarketSegmentsId",
                table: "BenefitMarketSegment");

            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_Category_CategoryId",
                table: "Benefits");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketSegmentDescription_MarketSegment_MarketSegmentId",
                table: "MarketSegmentDescription");

            migrationBuilder.DropTable(
                name: "CategoryDescription");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketSegment",
                table: "MarketSegment");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Benefits");

            migrationBuilder.RenameTable(
                name: "MarketSegment",
                newName: "MarketSegments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketSegments",
                table: "MarketSegments",
                column: "Id");

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
                name: "FK_BenefitMarketSegment_MarketSegments_MarketSegmentsId",
                table: "BenefitMarketSegment",
                column: "MarketSegmentsId",
                principalTable: "MarketSegments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_OfBenefitsCategories_CategoryId",
                table: "Benefits",
                column: "CategoryId",
                principalTable: "OfBenefitsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketSegmentDescription_MarketSegments_MarketSegmentId",
                table: "MarketSegmentDescription",
                column: "MarketSegmentId",
                principalTable: "MarketSegments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BenefitMarketSegment_MarketSegments_MarketSegmentsId",
                table: "BenefitMarketSegment");

            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_OfBenefitsCategories_CategoryId",
                table: "Benefits");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketSegmentDescription_MarketSegments_MarketSegmentId",
                table: "MarketSegmentDescription");

            migrationBuilder.DropTable(
                name: "OfBenefitsCategoryDescription");

            migrationBuilder.DropTable(
                name: "OfBenefitsCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketSegments",
                table: "MarketSegments");

            migrationBuilder.RenameTable(
                name: "MarketSegments",
                newName: "MarketSegment");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Benefits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketSegment",
                table: "MarketSegment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDescription",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDescription", x => new { x.CategoryId, x.Language });
                    table.ForeignKey(
                        name: "FK_CategoryDescription_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BenefitMarketSegment_MarketSegment_MarketSegmentsId",
                table: "BenefitMarketSegment",
                column: "MarketSegmentsId",
                principalTable: "MarketSegment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_Category_CategoryId",
                table: "Benefits",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketSegmentDescription_MarketSegment_MarketSegmentId",
                table: "MarketSegmentDescription",
                column: "MarketSegmentId",
                principalTable: "MarketSegment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
