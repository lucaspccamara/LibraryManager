using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class Update_Not_Mapped_Props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_Book_IdBookId",
                table: "LoanHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanHistory_User_IdUsuId",
                table: "LoanHistory");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistory_IdBookId",
                table: "LoanHistory");

            migrationBuilder.DropIndex(
                name: "IX_LoanHistory_IdUsuId",
                table: "LoanHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDateStr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedDateStr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedDateStr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedDateStr",
                table: "LoanHistory");

            migrationBuilder.DropColumn(
                name: "DeletedDateStr",
                table: "LoanHistory");

            migrationBuilder.DropColumn(
                name: "IdBookId",
                table: "LoanHistory");

            migrationBuilder.DropColumn(
                name: "IdUsuId",
                table: "LoanHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedDateStr",
                table: "LoanHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDateStr",
                table: "BookTheme");

            migrationBuilder.DropColumn(
                name: "DeletedDateStr",
                table: "BookTheme");

            migrationBuilder.DropColumn(
                name: "UpdatedDateStr",
                table: "BookTheme");

            migrationBuilder.DropColumn(
                name: "CreatedDateStr",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "DeletedDateStr",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "UpdatedDateStr",
                table: "Book");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "LoanHistory",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "LoanHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LoanHistory",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_User_UserId",
                table: "LoanHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "LoanHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LoanHistory");

            migrationBuilder.AddColumn<string>(
                name: "CreatedDateStr",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedDateStr",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedDateStr",
                table: "User",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnDate",
                table: "LoanHistory",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDateStr",
                table: "LoanHistory",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedDateStr",
                table: "LoanHistory",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdBookId",
                table: "LoanHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuId",
                table: "LoanHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedDateStr",
                table: "LoanHistory",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDateStr",
                table: "BookTheme",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedDateStr",
                table: "BookTheme",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedDateStr",
                table: "BookTheme",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDateStr",
                table: "Book",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedDateStr",
                table: "Book",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedDateStr",
                table: "Book",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_IdBookId",
                table: "LoanHistory",
                column: "IdBookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_IdUsuId",
                table: "LoanHistory",
                column: "IdUsuId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_Book_IdBookId",
                table: "LoanHistory",
                column: "IdBookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanHistory_User_IdUsuId",
                table: "LoanHistory",
                column: "IdUsuId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
