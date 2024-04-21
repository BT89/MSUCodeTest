using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSUCodeTest.Migrations
{
    /// <inheritdoc />
    public partial class thirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "messages",
                newName: "MessageDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageDateTime",
                table: "messages",
                newName: "dateTime");
        }
    }
}
