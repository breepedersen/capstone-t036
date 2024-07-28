using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JuniorRangers_API.Migrations
{
    /// <inheritdoc />
    public partial class missioncomplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45f9c41b-af5a-43d2-8fbf-77d533f58bbf", null, "Admin", "ADMIN" },
                    { "62139500-16bc-4fc4-8fec-813ec4a8915a", null, "Ranger", "RANGER" },
                    { "7c1d3267-f33d-406f-b065-42524783b0a6", null, "Student", "STUDENT" }
                });
        }
    }
}
