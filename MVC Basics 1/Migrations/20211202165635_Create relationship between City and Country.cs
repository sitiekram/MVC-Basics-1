using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class CreaterelationshipbetweenCityandCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryCode",
                table: "Cities",
                column: "CountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryCode",
                table: "Cities",
                column: "CountryCode",
                principalTable: "Countries",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryCode",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryCode",
                table: "Cities");
        }
    }
}
