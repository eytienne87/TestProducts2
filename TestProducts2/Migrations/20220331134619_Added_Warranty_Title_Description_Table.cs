using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProducts2.Migrations
{
    public partial class Added_Warranty_Title_Description_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "WarrantyTitles");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarrantyTitleDescription");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WarrantyTitles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
