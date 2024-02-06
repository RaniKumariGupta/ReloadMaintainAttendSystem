using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialDashbord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MarkAttendance",
                table: "Dashboard",
                newName: "isPresent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isPresent",
                table: "Dashboard",
                newName: "MarkAttendance");
        }
    }
}
