using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuniorRangers_API.Migrations
{
    /// <inheritdoc />
    public partial class amendmissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAwarded",
                table: "Achievements");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAwarded",
                table: "UserAchievements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MissionGroup",
                table: "Achievements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAwarded",
                table: "UserAchievements");

            migrationBuilder.DropColumn(
                name: "MissionGroup",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Achievements");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAwarded",
                table: "Achievements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
