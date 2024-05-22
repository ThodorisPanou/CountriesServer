using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountriesServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "Country");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Countries",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Population",
                table: "Countries",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "GDP",
                table: "Countries",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Countries",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Countries",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Countries",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "GDP",
                table: "Countries",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Countries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");
        }
    }
}
