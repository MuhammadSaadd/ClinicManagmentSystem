using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagmentSystem.API.Migrations
{
    public partial class newUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsttName",
                table: "Physicians",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Physicians",
                newName: "FirsttName");
        }
    }
}
