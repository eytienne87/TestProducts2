using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProducts2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StyleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StyleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantiesLengths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantiesLengths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantiesNotabenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantiesNotabenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarrantiesTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantiesTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBenefit",
                columns: table => new
                {
                    BenefitId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBenefit", x => new { x.ProductId, x.BenefitId });
                    table.ForeignKey(
                        name: "FK_ProductBenefit_Benefit_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Benefit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBenefit_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWarranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WarrantyTitleId = table.Column<int>(type: "int", nullable: false),
                    WarrantyLengthId = table.Column<int>(type: "int", nullable: false),
                    WarrantyNotaBeneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWarranties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductWarranties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWarranties_WarrantiesLengths_WarrantyLengthId",
                        column: x => x.WarrantyLengthId,
                        principalTable: "WarrantiesLengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWarranties_WarrantiesNotabenes_WarrantyNotaBeneId",
                        column: x => x.WarrantyNotaBeneId,
                        principalTable: "WarrantiesNotabenes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductWarranties_WarrantiesTitles_WarrantyTitleId",
                        column: x => x.WarrantyTitleId,
                        principalTable: "WarrantiesTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarranties_ProductId",
                table: "ProductWarranties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarranties_WarrantyLengthId",
                table: "ProductWarranties",
                column: "WarrantyLengthId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarranties_WarrantyNotaBeneId",
                table: "ProductWarranties",
                column: "WarrantyNotaBeneId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWarranties_WarrantyTitleId",
                table: "ProductWarranties",
                column: "WarrantyTitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductBenefit");

            migrationBuilder.DropTable(
                name: "ProductWarranties");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WarrantiesLengths");

            migrationBuilder.DropTable(
                name: "WarrantiesNotabenes");

            migrationBuilder.DropTable(
                name: "WarrantiesTitles");
        }
    }
}
