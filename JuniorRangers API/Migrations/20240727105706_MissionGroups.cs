using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JuniorRangers_API.Migrations
{
    /// <inheritdoc />
    public partial class MissionGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e554b86-d2b8-4552-a3fc-30303bb2b99f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2657876c-7e93-44cd-9a94-2a4df1a138ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75f70aed-8d78-483d-a36c-84d462947011");

            migrationBuilder.DropColumn(
                name: "MissionGroup",
                table: "Achievements");

            migrationBuilder.AlterColumn<string>(
                name: "JoinCode",
                table: "Classrooms",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "MissionGroups",
                columns: table => new
                {
                    MissionGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionGroups", x => x.MissionGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AchievementMissionGroup",
                columns: table => new
                {
                    AchievementsAchievementId = table.Column<int>(type: "int", nullable: false),
                    MissionGroupsMissionGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementMissionGroup", x => new { x.AchievementsAchievementId, x.MissionGroupsMissionGroupId });
                    table.ForeignKey(
                        name: "FK_AchievementMissionGroup_Achievements_AchievementsAchievementId",
                        column: x => x.AchievementsAchievementId,
                        principalTable: "Achievements",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AchievementMissionGroup_MissionGroups_MissionGroupsMissionGroupId",
                        column: x => x.MissionGroupsMissionGroupId,
                        principalTable: "MissionGroups",
                        principalColumn: "MissionGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AchievementMissionGroups",
                columns: table => new
                {
                    AchievementId = table.Column<int>(type: "int", nullable: false),
                    MissionGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementMissionGroups", x => new { x.AchievementId, x.MissionGroupId });
                    table.ForeignKey(
                        name: "FK_AchievementMissionGroups_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AchievementMissionGroups_MissionGroups_MissionGroupId",
                        column: x => x.MissionGroupId,
                        principalTable: "MissionGroups",
                        principalColumn: "MissionGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassMissions",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    MissionGroupId = table.Column<int>(type: "int", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMissions", x => new { x.ClassId, x.MissionGroupId });
                    table.ForeignKey(
                        name: "FK_ClassMissions_Classrooms_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classrooms",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassMissions_MissionGroups_MissionGroupId",
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
                    { "45f9c41b-af5a-43d2-8fbf-77d533f58bbf", null, "Admin", "ADMIN" },
                    { "62139500-16bc-4fc4-8fec-813ec4a8915a", null, "Ranger", "RANGER" },
                    { "7c1d3267-f33d-406f-b065-42524783b0a6", null, "Student", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementMissionGroup_MissionGroupsMissionGroupId",
                table: "AchievementMissionGroup",
                column: "MissionGroupsMissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementMissionGroups_MissionGroupId",
                table: "AchievementMissionGroups",
                column: "MissionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassMissions_MissionGroupId",
                table: "ClassMissions",
                column: "MissionGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementMissionGroup");

            migrationBuilder.DropTable(
                name: "AchievementMissionGroups");

            migrationBuilder.DropTable(
                name: "ClassMissions");

            migrationBuilder.DropTable(
                name: "MissionGroups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45f9c41b-af5a-43d2-8fbf-77d533f58bbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62139500-16bc-4fc4-8fec-813ec4a8915a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c1d3267-f33d-406f-b065-42524783b0a6");

            migrationBuilder.AlterColumn<string>(
                name: "JoinCode",
                table: "Classrooms",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<int>(
                name: "MissionGroup",
                table: "Achievements",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e554b86-d2b8-4552-a3fc-30303bb2b99f", null, "Admin", "ADMIN" },
                    { "2657876c-7e93-44cd-9a94-2a4df1a138ea", null, "Ranger", "RANGER" },
                    { "75f70aed-8d78-483d-a36c-84d462947011", null, "Student", "STUDENT" }
                });
        }
    }
}
