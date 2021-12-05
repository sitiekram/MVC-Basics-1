using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class Seedmoredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Languages",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageID", "Description", "Name" },
                values: new object[] { 1, "The international language spoken by many people around the world", "English" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageID", "Description", "Name" },
                values: new object[] { 2, "The  second international language spoken by in the different region of the world", "Arabic" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageID", "Description", "Name" },
                values: new object[] { 3, "The main language spoken in the Sweden Country", "Swedish" });

            migrationBuilder.InsertData(
                table: "PeopleLanguages",
                columns: new[] { "PersonId", "LanguageID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PeopleLanguages",
                keyColumns: new[] { "PersonId", "LanguageID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguages",
                keyColumns: new[] { "PersonId", "LanguageID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguages",
                keyColumns: new[] { "PersonId", "LanguageID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguages",
                keyColumns: new[] { "PersonId", "LanguageID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguages",
                keyColumns: new[] { "PersonId", "LanguageID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguages",
                keyColumns: new[] { "PersonId", "LanguageID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PeopleLanguages",
                keyColumns: new[] { "PersonId", "LanguageID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageID",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Languages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
