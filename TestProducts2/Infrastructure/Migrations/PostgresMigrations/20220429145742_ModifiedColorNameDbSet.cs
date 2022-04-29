using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.PostgresMigrations
{
    public partial class ModifiedColorNameDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ColorName",
                table: "ColorName");

            migrationBuilder.RenameTable(
                name: "ColorName",
                newName: "ColorNames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColorNames",
                table: "ColorNames",
                columns: new[] { "ProductType", "ColorCode" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ColorNames",
                table: "ColorNames");

            migrationBuilder.RenameTable(
                name: "ColorNames",
                newName: "ColorName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColorName",
                table: "ColorName",
                columns: new[] { "ProductType", "ColorCode" });
        }
    }
}
