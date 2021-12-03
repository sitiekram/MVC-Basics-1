using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class CreateCountryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Continent = table.Column<int>(nullable: false),
                    Region = table.Column<string>(maxLength: 25, nullable: false),
                    Population = table.Column<int>(nullable: false),
                    SurfaceArea = table.Column<float>(nullable: false),
                    HeadOfState = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
