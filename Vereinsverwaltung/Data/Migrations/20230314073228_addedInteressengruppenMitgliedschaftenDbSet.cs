using Microsoft.EntityFrameworkCore.Migrations;

namespace Vereinsverwaltung.Data.Migrations
{
    public partial class addedInteressengruppenMitgliedschaftenDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interessengruppen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interessengruppen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mitgliedschaften",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    IdInteressengruppe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitgliedschaften", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interessengruppen");

            migrationBuilder.DropTable(
                name: "Mitgliedschaften");
        }
    }
}
