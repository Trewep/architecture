using Microsoft.EntityFrameworkCore.Migrations;

namespace OurProject.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    eventName = table.Column<string>(type: "TEXT", nullable: true),
                    eventDate = table.Column<string>(type: "TEXT", nullable: true),
                    eventDescription = table.Column<string>(type: "TEXT", nullable: true),
                    eventMinAge = table.Column<int>(type: "INTEGER", nullable: false),
                    eventMaxAge = table.Column<int>(type: "INTEGER", nullable: false),
                    eventEnroll = table.Column<bool>(type: "INTEGER", nullable: false),
                    eventEnrollDate = table.Column<string>(type: "TEXT", nullable: true),
                    eventCounter = table.Column<int>(type: "INTEGER", nullable: false),
                    eventPersonList = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    personName = table.Column<string>(type: "TEXT", nullable: true),
                    personBirth = table.Column<string>(type: "TEXT", nullable: true),
                    personMail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
