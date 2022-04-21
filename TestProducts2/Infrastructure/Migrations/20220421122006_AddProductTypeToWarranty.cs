using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddProductTypeToWarranty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "MarketSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UrlName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSegments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    StyleCode = table.Column<string>(type: "text", nullable: false),
                    StyleName = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyLengths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyLengths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyNotabenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyNotabenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_CategoryOfBenefits_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryOfBenefits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryOfBenefitDescription",
                columns: table => new
                {
                    CategoryOfBenefitId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOfBenefitDescription", x => new { x.CategoryOfBenefitId, x.Language });
                    table.ForeignKey(
                        name: "FK_CategoryOfBenefitDescription_CategoryOfBenefits_CategoryOfB~",
                        column: x => x.CategoryOfBenefitId,
                        principalTable: "CategoryOfBenefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketSegmentDescription",
                columns: table => new
                {
                    MarketSegmentId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSegmentDescription", x => new { x.MarketSegmentId, x.Language });
                    table.ForeignKey(
                        name: "FK_MarketSegmentDescription_MarketSegments_MarketSegmentId",
                        column: x => x.MarketSegmentId,
                        principalTable: "MarketSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyLengthDescription",
                columns: table => new
                {
                    WarrantyLengthId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyLengthDescription", x => new { x.WarrantyLengthId, x.Language });
                    table.ForeignKey(
                        name: "FK_WarrantyLengthDescription_WarrantyLengths_WarrantyLengthId",
                        column: x => x.WarrantyLengthId,
                        principalTable: "WarrantyLengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyNotabeneDescription",
                columns: table => new
                {
                    WarrantyNotabeneId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyNotabeneDescription", x => new { x.WarrantyNotabeneId, x.Language });
                    table.ForeignKey(
                        name: "FK_WarrantyNotabeneDescription_WarrantyNotabenes_WarrantyNotab~",
                        column: x => x.WarrantyNotabeneId,
                        principalTable: "WarrantyNotabenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarrantyTitleId = table.Column<int>(type: "integer", nullable: false),
                    WarrantyLengthId = table.Column<int>(type: "integer", nullable: false),
                    WarrantyNotabeneId = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warranties_WarrantyLengths_WarrantyLengthId",
                        column: x => x.WarrantyLengthId,
                        principalTable: "WarrantyLengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Warranties_WarrantyNotabenes_WarrantyNotabeneId",
                        column: x => x.WarrantyNotabeneId,
                        principalTable: "WarrantyNotabenes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Warranties_WarrantyTitles_WarrantyTitleId",
                        column: x => x.WarrantyTitleId,
                        principalTable: "WarrantyTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyTitleDescription",
                columns: table => new
                {
                    WarrantyTitleId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyTitleDescription", x => new { x.WarrantyTitleId, x.Language });
                    table.ForeignKey(
                        name: "FK_WarrantyTitleDescription_WarrantyTitles_WarrantyTitleId",
                        column: x => x.WarrantyTitleId,
                        principalTable: "WarrantyTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitDescription",
                columns: table => new
                {
                    BenefitId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitDescription", x => new { x.BenefitId, x.Language });
                    table.ForeignKey(
                        name: "FK_BenefitDescription_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitMarketSegment",
                columns: table => new
                {
                    BenefitsId = table.Column<int>(type: "integer", nullable: false),
                    MarketSegmentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitMarketSegment", x => new { x.BenefitsId, x.MarketSegmentsId });
                    table.ForeignKey(
                        name: "FK_BenefitMarketSegment_Benefits_BenefitsId",
                        column: x => x.BenefitsId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitMarketSegment_MarketSegments_MarketSegmentsId",
                        column: x => x.MarketSegmentsId,
                        principalTable: "MarketSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitProduct",
                columns: table => new
                {
                    BenefitsId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitProduct", x => new { x.BenefitsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_BenefitProduct_Benefits_BenefitsId",
                        column: x => x.BenefitsId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWarranty",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "integer", nullable: false),
                    WarrantiesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarranty", x => new { x.ProductsId, x.WarrantiesId });
                    table.ForeignKey(
                        name: "FK_ProductWarranty_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWarranty_Warranties_WarrantiesId",
                        column: x => x.WarrantiesId,
                        principalTable: "Warranties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitMarketSegment_MarketSegmentsId",
                table: "BenefitMarketSegment",
                column: "MarketSegmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitProduct_ProductsId",
                table: "BenefitProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_CategoryId",
                table: "Benefits",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarranty_WarrantiesId",
                table: "ProductWarranty",
                column: "WarrantiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_WarrantyLengthId",
                table: "Warranties",
                column: "WarrantyLengthId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_WarrantyNotabeneId",
                table: "Warranties",
                column: "WarrantyNotabeneId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranties_WarrantyTitleId",
                table: "Warranties",
                column: "WarrantyTitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitDescription");

            migrationBuilder.DropTable(
                name: "BenefitMarketSegment");

            migrationBuilder.DropTable(
                name: "BenefitProduct");

            migrationBuilder.DropTable(
                name: "CategoryOfBenefitDescription");

            migrationBuilder.DropTable(
                name: "MarketSegmentDescription");

            migrationBuilder.DropTable(
                name: "ProductWarranty");

            migrationBuilder.DropTable(
                name: "WarrantyLengthDescription");

            migrationBuilder.DropTable(
                name: "WarrantyNotabeneDescription");

            migrationBuilder.DropTable(
                name: "WarrantyTitleDescription");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "MarketSegments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.DropTable(
                name: "CategoryOfBenefits");

            migrationBuilder.DropTable(
                name: "WarrantyLengths");

            migrationBuilder.DropTable(
                name: "WarrantyNotabenes");

            migrationBuilder.DropTable(
                name: "WarrantyTitles");
        }
    }
}
