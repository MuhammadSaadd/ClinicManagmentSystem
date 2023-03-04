using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagmentSystem.API.Migrations
{
    public partial class EditPhysicianFirstName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FisrtName",
                table: "Physicians",
                newName: "FirsttName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsttName",
                table: "Physicians",
                newName: "FisrtName");
        }
    }
}
