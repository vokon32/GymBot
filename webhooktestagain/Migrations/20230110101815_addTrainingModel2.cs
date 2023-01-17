using Microsoft.EntityFrameworkCore.Migrations;

namespace webhooktestagain.Migrations
{
    public partial class addTrainingModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AppUserId",
                table: "Trainings",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "Trainings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_AppUserId",
                table: "Trainings",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Users_AppUserId",
                table: "Trainings",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Users_AppUserId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_AppUserId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Trainings");
        }
    }
}
