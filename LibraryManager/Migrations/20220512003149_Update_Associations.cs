using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class Update_Associations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistory_BookId",
                table: "LoanHistory");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistory_UserId",
                table: "LoanHistory");

            migrationBuilder.AddColumn<int>(
                name: "LoanHistoryId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanHistoryId",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_LoanHistoryId",
                table: "User",
                column: "LoanHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LoanHistoryId",
                table: "Book",
                column: "LoanHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_LoanHistory_LoanHistoryId",
                table: "Book",
                column: "LoanHistoryId",
                principalTable: "LoanHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoanHistory_LoanHistoryId",
                table: "User",
                column: "LoanHistoryId",
                principalTable: "LoanHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_LoanHistory_LoanHistoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_User_LoanHistory_LoanHistoryId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LoanHistoryId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Book_LoanHistoryId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LoanHistoryId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LoanHistoryId",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_BookId",
                table: "LoanHistory",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_UserId",
                table: "LoanHistory",
                column: "UserId");

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
    }
}
