using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class Createrelationshipbetweencityandpeole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "HeadOfState",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "SurfaceArea",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_People_CityID",
                table: "People",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityID",
                table: "People",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CityID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeadOfState",
                table: "Countries",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Countries",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SurfaceArea",
                table: "Countries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Cities",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "Continent", "HeadOfState", "Name", "Population", "Region", "SurfaceArea" },
                values: new object[] { "GHA", "Africa", "John Kufuor", "Ghana", 20212000, "Western Africa", 238533.0 });

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
    }
}
