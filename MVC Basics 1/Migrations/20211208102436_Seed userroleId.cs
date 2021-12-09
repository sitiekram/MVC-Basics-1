using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class SeeduserroleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41602ae-7b3d-4ec2-8d46-c7dcfcae12e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f082685-45da-451d-af43-cac5d88cc2e0");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "e41602ae-7b3d-4ec2-8d46-c7dcfcae12e4", "85f5864b-26e2-46e6-bef8-e8995d404231", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f082685-45da-451d-af43-cac5d88cc2e0", 0, "062150de-7b60-432e-a0c6-53514b94ec54", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEKtayE5JRxdCvyLUj54fEtE3EdzjTkIZHJQyb3SAXxQljC6kcP3U5rbdn3AiQ98AZw==", null, false, "5cbdfe8a-01a7-4cc2-9751-dfc372f23c06", false, "Admin" });
        }
    }
}
