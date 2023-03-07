using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagmentSystem.API.Migrations
{
    public partial class AddTableEpisodeVisitJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpisodeVisitJobs",
                columns: table => new
                {
                    EpisodeVisitJobId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppointmentJobId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeVisitJobs", x => x.EpisodeVisitJobId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeVisitJobs");
        }
    }
}
