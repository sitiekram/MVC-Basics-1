using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class Seedednewdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "Continent", "Name", "Population" },
                values: new object[,]
                {
                    { "GHA", "Africa", "Ghana", 20212000 },
                    { "GBR", "Europe", "United Kingdom", 59623400 },
                    { "SWE", "Europe", "Sweden", 10188382 },
                    { "USA", "North America", "United States", 278357000 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CountryCode", "Name", "Population" },
                values: new object[,]
                {
                    { 5, "GBR", "London", 961989 },
                    { 1, "SWE", "Vänersborg", 39606 },
                    { 2, "SWE", "Göteborg", 1060000 },
                    { 3, "SWE", "Stockholm", 1657000 },
                    { 4, "SWE", "Trollhättan", 54487 },
                    { 6, "USA", "Washington D.C.", 689545 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CityID", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "ekram234@gmail.com", "Ekram Ahmedin", "0791234567" },
                    { 3, 1, "ulf78s3@hotmail.com", "Ulf David", "0752875207" },
                    { 2, 2, "timsnds241@gmail.com", "Eve Andersson", "+46701297530" },
                    { 5, 3, "mariaSvensson234@gmail.com", "Maria Svensson", "+46791028376" },
                    { 6, 3, "RahwaSuliman1234@gmail.com", "Rahwa Suliman", "0764933276" },
                    { 4, 4, "alimuhammed@gmail.com", "Ali Muhammed", "0796078542" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "GHA");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "GBR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "USA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "SWE");
        }
    }
}
