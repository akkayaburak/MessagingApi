using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessagingApi.Migrations.SqlServerMigrations
{
    public partial class Blocks_edited2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockById = table.Column<int>(nullable: false),
                    BlockToId = table.Column<int>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Users_BlockById",
                        column: x => x.BlockById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blocks_Users_BlockToId",
                        column: x => x.BlockToId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockById",
                table: "Blocks",
                column: "BlockById");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_BlockToId",
                table: "Blocks",
                column: "BlockToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
