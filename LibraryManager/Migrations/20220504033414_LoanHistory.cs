using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManager.Migrations
{
    public partial class LoanHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedDateStr = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDateStr = table.Column<string>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedDateStr = table.Column<string>(nullable: true),
                    IndAtivo = table.Column<int>(nullable: false),
                    IdUsuId = table.Column<int>(nullable: true),
                    IdBookId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    LoanType = table.Column<int>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    ReturnDeadline = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanHistory_Book_IdBookId",
                        column: x => x.IdBookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanHistory_User_IdUsuId",
                        column: x => x.IdUsuId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_IdBookId",
                table: "LoanHistory",
                column: "IdBookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistory_IdUsuId",
                table: "LoanHistory",
                column: "IdUsuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanHistory");
        }
    }
}
