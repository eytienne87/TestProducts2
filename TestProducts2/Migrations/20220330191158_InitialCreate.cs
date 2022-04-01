using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TestProducts2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    StyleCode = table.Column<string>(type: "text", nullable: false),
                    StyleName = table.Column<string>(type: "text", nullable: false)
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
                    Name = table.Column<string>(type: "text", nullable: false)
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
                    Name = table.Column<string>(type: "text", nullable: false)
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
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyTitles", x => x.Id);
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
                name: "Warranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarrantyTitleId = table.Column<int>(type: "integer", nullable: false),
                    WarrantyLengthId = table.Column<int>(type: "integer", nullable: false),
                    WarrantyNotabeneId = table.Column<int>(type: "integer", nullable: true)
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
                name: "IX_BenefitProduct_ProductsId",
                table: "BenefitProduct",
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
                name: "BenefitDescription");

            migrationBuilder.DropTable(
                name: "BenefitProduct");

            migrationBuilder.DropTable(
                name: "ProductWarranty");

            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.DropTable(
                name: "WarrantyLengths");

            migrationBuilder.DropTable(
                name: "WarrantyNotabenes");

            migrationBuilder.DropTable(
                name: "WarrantyTitles");
        }
    }
}
