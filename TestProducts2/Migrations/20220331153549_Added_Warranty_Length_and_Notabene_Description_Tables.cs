using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProducts2.Migrations
{
    public partial class Added_Warranty_Length_and_Notabene_Description_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WarrantyNotabenes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WarrantyLengths");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarrantyLengthDescription");

            migrationBuilder.DropTable(
                name: "WarrantyNotabeneDescription");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WarrantyNotabenes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WarrantyLengths",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
