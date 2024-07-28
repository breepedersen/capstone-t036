using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JuniorRangers_API.Migrations
{
    /// <inheritdoc />
    public partial class ClassMissionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26dacc87-13ec-45a6-93ea-9a246a19ac59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b03480-cb6d-44a6-b7cb-a6bcc845005d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec4678e0-af5b-4309-98ad-09b1f38c94e6");

            migrationBuilder.DropColumn(
                name: "IsCompletedClassMission",
                table: "Achievements");

            migrationBuilder.CreateTable(
                name: "ClassMissionStatuses",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    MissionGroupId = table.Column<int>(type: "int", nullable: false),
                    AchievementId = table.Column<int>(type: "int", nullable: false),
                    IsAchievementComplete = table.Column<bool>(type: "bit", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMissionStatuses", x => new { x.ClassroomId, x.MissionGroupId, x.AchievementId });
                    table.ForeignKey(
                        name: "FK_ClassMissionStatuses_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassMissionStatuses_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassMissionStatuses_MissionGroups_MissionGroupId",
                        column: x => x.MissionGroupId,
                        principalTable: "MissionGroups",
                        principalColumn: "MissionGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f4fa9d4-0866-4f90-a6a3-4bdb4638f10f", null, "Student", "STUDENT" },
                    { "251064fb-d8ca-4a0e-b52e-c72b7cb7e9a8", null, "Admin", "ADMIN" },
                    { "9aa53610-498b-4259-a640-01f7036270cb", null, "Ranger", "RANGER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassMissionStatuses_AchievementId",
                table: "ClassMissionStatuses",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassMissionStatuses_MissionGroupId",
                table: "ClassMissionStatuses",
                column: "MissionGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassMissionStatuses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f4fa9d4-0866-4f90-a6a3-4bdb4638f10f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "251064fb-d8ca-4a0e-b52e-c72b7cb7e9a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa53610-498b-4259-a640-01f7036270cb");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompletedClassMission",
                table: "Achievements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26dacc87-13ec-45a6-93ea-9a246a19ac59", null, "Ranger", "RANGER" },
                    { "44b03480-cb6d-44a6-b7cb-a6bcc845005d", null, "Student", "STUDENT" },
                    { "ec4678e0-af5b-4309-98ad-09b1f38c94e6", null, "Admin", "ADMIN" }
                });
        }
    }
}
