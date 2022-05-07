using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class LoanHistoryForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LoanHistory",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "LoanHistory",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LoanHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "LoanHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
