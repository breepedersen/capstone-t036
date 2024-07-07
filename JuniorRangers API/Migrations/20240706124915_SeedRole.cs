using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JuniorRangers_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bc03388-f3e1-45e0-a317-e50db62844a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e393468-8a3d-46da-8c25-58c77c83dfa5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0779205d-d248-429b-bf92-59e22ea3771a", null, "Student", "STUDENT" },
                    { "0a7bb448-f72c-47ca-bf4d-8fc8fbb19b25", null, "Ranger", "RANGER" },
                    { "a74667d6-dba2-43f5-8777-36bb350a1541", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0779205d-d248-429b-bf92-59e22ea3771a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a7bb448-f72c-47ca-bf4d-8fc8fbb19b25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a74667d6-dba2-43f5-8777-36bb350a1541");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bc03388-f3e1-45e0-a317-e50db62844a5", null, "Admin", "ADMIN" },
                    { "9e393468-8a3d-46da-8c25-58c77c83dfa5", null, "User", "USER" }
                });
        }
    }
}
