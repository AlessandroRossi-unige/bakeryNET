using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddedFieldsToSweet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Sweets_SweetId",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sweets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Sweets",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SweetId",
                table: "Ingredients",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Sweets_SweetId",
                table: "Ingredients",
                column: "SweetId",
                principalTable: "Sweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Sweets_SweetId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sweets");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Sweets");

            migrationBuilder.AlterColumn<int>(
                name: "SweetId",
                table: "Ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Sweets_SweetId",
                table: "Ingredients",
                column: "SweetId",
                principalTable: "Sweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
