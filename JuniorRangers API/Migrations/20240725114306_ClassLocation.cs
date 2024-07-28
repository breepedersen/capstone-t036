using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JuniorRangers_API.Migrations
{
    /// <inheritdoc />
    public partial class ClassLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a86cb35-716c-49f8-ba61-4c95ab2e4d8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8fb6043-885e-41a7-991d-31e4782bc220");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3f00232-a907-446b-becf-08a65bad9016");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Classrooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Location",
                table: "Classrooms");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a86cb35-716c-49f8-ba61-4c95ab2e4d8f", null, "Student", "STUDENT" },
                    { "a8fb6043-885e-41a7-991d-31e4782bc220", null, "Ranger", "RANGER" },
                    { "b3f00232-a907-446b-becf-08a65bad9016", null, "Admin", "ADMIN" }
                });
        }
    }
}
