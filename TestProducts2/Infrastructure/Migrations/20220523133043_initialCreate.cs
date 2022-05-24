using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbrasionResistances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbrasionResistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSegments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyLengths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyLengths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyNotabenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyNotabenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbrasionResistanceDescriptions",
                columns: table => new
                {
                    AbrasionResistanceId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbrasionResistanceDescriptions", x => new { x.AbrasionResistanceId, x.Language });
                    table.ForeignKey(
                        name: "FK_AbrasionResistanceDescriptions_AbrasionResistances_AbrasionResistanceId",
                        column: x => x.AbrasionResistanceId,
                        principalTable: "AbrasionResistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StyleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbrasionId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AbrasionResistances_AbrasionId",
                        column: x => x.AbrasionId,
                        principalTable: "AbrasionResistances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BenefitCategoryDescriptions",
                columns: table => new
                {
                    CategoryOfBenefitId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BenefitCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitCategoryDescriptions", x => new { x.CategoryOfBenefitId, x.Language });
                    table.ForeignKey(
                        name: "FK_BenefitCategoryDescriptions_BenefitCategories_BenefitCategoryId",
                        column: x => x.BenefitCategoryId,
                        principalTable: "BenefitCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_BenefitCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BenefitCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MarketSegmentDescriptions",
                columns: table => new
                {
                    MarketSegmentId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSegmentDescriptions", x => new { x.MarketSegmentId, x.Language });
                    table.ForeignKey(
                        name: "FK_MarketSegmentDescriptions_MarketSegments_MarketSegmentId",
                        column: x => x.MarketSegmentId,
                        principalTable: "MarketSegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyLengthDescriptions",
                columns: table => new
                {
                    WarrantyLengthId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyLengthDescriptions", x => new { x.WarrantyLengthId, x.Language });
                    table.ForeignKey(
                        name: "FK_WarrantyLengthDescriptions_WarrantyLengths_WarrantyLengthId",
                        column: x => x.WarrantyLengthId,
                        principalTable: "WarrantyLengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyNotabeneDescriptions",
                columns: table => new
                {
                    WarrantyNotabeneId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyNotabeneDescriptions", x => new { x.WarrantyNotabeneId, x.Language });
                    table.ForeignKey(
                        name: "FK_WarrantyNotabeneDescriptions_WarrantyNotabenes_WarrantyNotabeneId",
                        column: x => x.WarrantyNotabeneId,
                        principalTable: "WarrantyNotabenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarrantyTitleId = table.Column<int>(type: "int", nullable: false),
                    WarrantyLengthId = table.Column<int>(type: "int", nullable: false),
                    WarrantyNotabeneId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "WarrantyTitleDescriptions",
                columns: table => new
                {
                    WarrantyTitleId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyTitleDescriptions", x => new { x.WarrantyTitleId, x.Language });
                    table.ForeignKey(
                        name: "FK_WarrantyTitleDescriptions_WarrantyTitles_WarrantyTitleId",
                        column: x => x.WarrantyTitleId,
                        principalTable: "WarrantyTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitDescriptions",
                columns: table => new
                {
                    BenefitId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitDescriptions", x => new { x.BenefitId, x.Language });
                    table.ForeignKey(
                        name: "FK_BenefitDescriptions_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenefitMarketSegment",
                columns: table => new
                {
                    BenefitsId = table.Column<int>(type: "int", nullable: false),
                    MarketSegmentsId = table.Column<int>(type: "int", nullable: false)
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
                name: "ProductsBenefits",
                columns: table => new
                {
                    BenefitsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsBenefits", x => new { x.BenefitsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductsBenefits_Benefits_BenefitsId",
                        column: x => x.BenefitsId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsBenefits_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWarranty",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    WarrantiesId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_BenefitCategoryDescriptions_BenefitCategoryId",
                table: "BenefitCategoryDescriptions",
                column: "BenefitCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitMarketSegment_MarketSegmentsId",
                table: "BenefitMarketSegment",
                column: "MarketSegmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_CategoryId",
                table: "Benefits",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AbrasionId",
                table: "Products",
                column: "AbrasionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsBenefits_ProductsId",
                table: "ProductsBenefits",
                column: "ProductsId");

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
                name: "AbrasionResistanceDescriptions");

            migrationBuilder.DropTable(
                name: "BenefitCategoryDescriptions");

            migrationBuilder.DropTable(
                name: "BenefitDescriptions");

            migrationBuilder.DropTable(
                name: "BenefitMarketSegment");

            migrationBuilder.DropTable(
                name: "MarketSegmentDescriptions");

            migrationBuilder.DropTable(
                name: "ProductsBenefits");

            migrationBuilder.DropTable(
                name: "ProductWarranty");

            migrationBuilder.DropTable(
                name: "WarrantyLengthDescriptions");

            migrationBuilder.DropTable(
                name: "WarrantyNotabeneDescriptions");

            migrationBuilder.DropTable(
                name: "WarrantyTitleDescriptions");

            migrationBuilder.DropTable(
                name: "MarketSegments");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.DropTable(
                name: "BenefitCategories");

            migrationBuilder.DropTable(
                name: "AbrasionResistances");

            migrationBuilder.DropTable(
                name: "WarrantyLengths");

            migrationBuilder.DropTable(
                name: "WarrantyNotabenes");

            migrationBuilder.DropTable(
                name: "WarrantyTitles");
        }
    }
}
