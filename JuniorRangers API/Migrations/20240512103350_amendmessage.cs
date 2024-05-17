using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuniorRangers_API.Migrations
{
    /// <inheritdoc />
    public partial class amendmessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MessageTitle",
                table: "Messages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageTitle",
                table: "Messages");
        }
    }
}
