using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuniorRangers_API.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classrooms_ClassroomClassId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomClassId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classrooms_ClassroomClassId",
                table: "Users",
                column: "ClassroomClassId",
                principalTable: "Classrooms",
                principalColumn: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classrooms_ClassroomClassId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomClassId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classrooms_ClassroomClassId",
                table: "Users",
                column: "ClassroomClassId",
                principalTable: "Classrooms",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
