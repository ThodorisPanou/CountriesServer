using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountriesServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    PopulationDensity = table.Column<double>(type: "REAL", nullable: false),
                    CoastlineRatio = table.Column<double>(type: "REAL", nullable: false),
                    NetMigration = table.Column<double>(type: "REAL", nullable: false),
                    InfantMortality = table.Column<double>(type: "REAL", nullable: false),
                    GDP = table.Column<int>(type: "INTEGER", nullable: false),
                    Literacy = table.Column<double>(type: "REAL", nullable: false),
                    Phones = table.Column<double>(type: "REAL", nullable: false),
                    Climate = table.Column<double>(type: "REAL", nullable: false),
                    Birthrate = table.Column<double>(type: "REAL", nullable: false),
                    Deathrate = table.Column<double>(type: "REAL", nullable: false),
                    Agriculture = table.Column<double>(type: "REAL", nullable: false),
                    Industry = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
