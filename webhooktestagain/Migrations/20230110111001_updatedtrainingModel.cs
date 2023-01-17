using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webhooktestagain.Migrations
{
    public partial class updatedtrainingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.AddColumn<long>(
                name: "AppUserId",
                table: "Exercises",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "Exercises",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_AppUserId",
                table: "Exercises",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Users_AppUserId",
                table: "Exercises",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Users_AppUserId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_AppUserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Exercises");

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_UserId",
                table: "Operations",
                column: "UserId");
        }
    }
}
