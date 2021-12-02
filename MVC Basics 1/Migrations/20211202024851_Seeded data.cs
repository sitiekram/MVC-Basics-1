using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class Seededdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Vänersborg", "ekram234@gmail.com", "Ekram Ahmedin", "0791234567" },
                    { 2, "Göteborg", "timsnds241@gmail.com", "Eve Andersson", "+46701297530" },
                    { 3, "Vänersborg", "ulf78s3@hotmail.com", "Ulf David", "0752875207" },
                    { 4, "Trollhättan", "alimuhammed@gmail.com", "Ali Muhammed", "0796078542" },
                    { 5, "Stockholm", "mariaSvensson234@gmail.com", "Maria Svensson", "+46791028376" },
                    { 6, "Stockholm", "RahwaSuliman1234@gmail.com", "Rahwa Suliman", "0764933276" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
