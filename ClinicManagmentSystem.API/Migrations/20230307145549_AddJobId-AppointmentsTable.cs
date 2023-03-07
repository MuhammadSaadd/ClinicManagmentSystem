using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagmentSystem.API.Migrations
{
    public partial class AddJobIdAppointmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JopId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JopId",
                table: "Appointments");
        }
    }
}
