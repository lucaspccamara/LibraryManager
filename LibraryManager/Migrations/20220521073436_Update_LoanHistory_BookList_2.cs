using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class Update_LoanHistory_BookList_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_LoanHistory_LoanHistoryId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_LoanHistoryId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LoanHistoryId",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_BookId",
                table: "LoanHistory",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_Book_BookId",
                table: "LoanHistory");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistory_BookId",
                table: "LoanHistory");

            migrationBuilder.AddColumn<int>(
                name: "LoanHistoryId",
                table: "Book",
                type: "int",
                nullable: true);

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
        }
    }
}
