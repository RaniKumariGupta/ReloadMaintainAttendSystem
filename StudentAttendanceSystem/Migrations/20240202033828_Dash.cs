using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.Migrations
{
    /// <inheritdoc />
    public partial class Dash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Dashboard",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dashboard",
                newName: "id");
        }
    }
}
