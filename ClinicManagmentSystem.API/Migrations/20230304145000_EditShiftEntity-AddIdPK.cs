using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagmentSystem.API.Migrations
{
    public partial class EditShiftEntityAddIdPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ClinicId",
                table: "Shifts",
                column: "ClinicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_ClinicId",
                table: "Shifts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                columns: new[] { "ClinicId", "PhysicianId" });
        }
    }
}
