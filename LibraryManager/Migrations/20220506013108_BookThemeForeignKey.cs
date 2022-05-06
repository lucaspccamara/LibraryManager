using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class BookThemeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookTheme_ThemeId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_ThemeId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookThemeId",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookThemeId",
                table: "Book",
                column: "BookThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookTheme_BookThemeId",
                table: "Book",
                column: "BookThemeId",
                principalTable: "BookTheme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookTheme_BookThemeId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookThemeId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookThemeId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_ThemeId",
                table: "Book",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookTheme_ThemeId",
                table: "Book",
                column: "ThemeId",
                principalTable: "BookTheme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
