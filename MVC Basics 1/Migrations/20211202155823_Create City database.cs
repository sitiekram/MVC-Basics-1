using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class CreateCitydatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SurfaceArea",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 3, nullable: false),
                    District = table.Column<string>(maxLength: 20, nullable: false),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "Continent", "HeadOfState", "Name", "Population", "Region", "SurfaceArea" },
                values: new object[] { "GHA", "Africa", "John Kufuor", "Ghana", 20212000, "Western Africa", 238533.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "GHA");

            migrationBuilder.AlterColumn<float>(
                name: "SurfaceArea",
                table: "Countries",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
