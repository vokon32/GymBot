using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webhooktestagain.Migrations
{
    public partial class addTrainingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "trainingId",
                table: "Exercises",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfTheTraining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_trainingId",
                table: "Exercises",
                column: "trainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainings_trainingId",
                table: "Exercises",
                column: "trainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainings_trainingId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_trainingId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "trainingId",
                table: "Exercises");
        }
    }
}
