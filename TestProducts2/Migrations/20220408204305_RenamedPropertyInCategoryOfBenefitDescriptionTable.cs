using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProducts2.Migrations
{
    public partial class RenamedPropertyInCategoryOfBenefitDescriptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryOfBenefitDescription_CategoryOfBenefits_CategoryOfB~",
                table: "CategoryOfBenefitDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryOfBenefitDescription",
                table: "CategoryOfBenefitDescription");

            migrationBuilder.DropIndex(
                name: "IX_CategoryOfBenefitDescription_CategoryOfBenefitId",
                table: "CategoryOfBenefitDescription");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CategoryOfBenefitDescription");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryOfBenefitId",
                table: "CategoryOfBenefitDescription",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryOfBenefitDescription",
                table: "CategoryOfBenefitDescription",
                columns: new[] { "CategoryOfBenefitId", "Language" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryOfBenefitDescription_CategoryOfBenefits_CategoryOfB~",
                table: "CategoryOfBenefitDescription",
                column: "CategoryOfBenefitId",
                principalTable: "CategoryOfBenefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryOfBenefitDescription_CategoryOfBenefits_CategoryOfB~",
                table: "CategoryOfBenefitDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryOfBenefitDescription",
                table: "CategoryOfBenefitDescription");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryOfBenefitId",
                table: "CategoryOfBenefitDescription",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CategoryOfBenefitDescription",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryOfBenefitDescription",
                table: "CategoryOfBenefitDescription",
                columns: new[] { "CategoryId", "Language" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryOfBenefitDescription_CategoryOfBenefitId",
                table: "CategoryOfBenefitDescription",
                column: "CategoryOfBenefitId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryOfBenefitDescription_CategoryOfBenefits_CategoryOfB~",
                table: "CategoryOfBenefitDescription",
                column: "CategoryOfBenefitId",
                principalTable: "CategoryOfBenefits",
                principalColumn: "Id");
        }
    }
}
