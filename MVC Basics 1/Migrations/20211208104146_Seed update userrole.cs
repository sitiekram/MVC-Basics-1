using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class Seedupdateuserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ee92ba7-b957-4e08-8a11-5ab4b8621b14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f181ae36-7fd5-4a45-a5bd-7a5f1a49d726");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ee3e48a-19ab-45cc-810b-d3597564e1cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9755d547-7bcb-4181-9dbc-60981d70299e", "48718ecf-b500-43f6-bec7-2a04ae2ce03e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c863b09e-7a5b-4bb1-ad52-5f505fc99373", "4f439d18-b165-460f-a177-b8437e52e3d0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66782338-4dfb-449e-bf79-a1465f86d6c2", 0, "c435fefd-30b9-410c-bae3-f4386c4e7a7f", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEOnP0nYaufa1n5Le2UeFzEXBMKy+X+2O45pf0aeGEdKOzhli1kC4vjPLZxpEy2mFeg==", null, false, "df011900-e983-49b1-9c34-8cbab3ed1dbc", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "66782338-4dfb-449e-bf79-a1465f86d6c2", "9755d547-7bcb-4181-9dbc-60981d70299e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c863b09e-7a5b-4bb1-ad52-5f505fc99373");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "66782338-4dfb-449e-bf79-a1465f86d6c2", "9755d547-7bcb-4181-9dbc-60981d70299e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9755d547-7bcb-4181-9dbc-60981d70299e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66782338-4dfb-449e-bf79-a1465f86d6c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ee92ba7-b957-4e08-8a11-5ab4b8621b14", "264e4d77-423f-4dc3-ab81-e90ebb573c7b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f181ae36-7fd5-4a45-a5bd-7a5f1a49d726", "975feda3-b849-456e-9996-12eea4927e3b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ee3e48a-19ab-45cc-810b-d3597564e1cb", 0, "112dbe51-438d-4bc6-b301-e9e725334feb", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAENqSDInlAV4TJk7xRlpuproWcCdTUium99w6yoHyLxdd++RyuQWpTAnwUqdf2UK4cQ==", null, false, "17b18ed0-aee5-459a-9893-eaaa9de270e7", false, "Admin" });
        }
    }
}
