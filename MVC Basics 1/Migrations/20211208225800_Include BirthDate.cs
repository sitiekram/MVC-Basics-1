using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class IncludeBirthDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c63ff628-336e-4283-b2ae-c9f6fd4dbecb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "7bbf880f-7576-410f-82c7-4692648034cf", "ba808787-0679-4ea6-b7ff-21944eae8d84" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba808787-0679-4ea6-b7ff-21944eae8d84");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bbf880f-7576-410f-82c7-4692648034cf");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26795f08-d2bb-4f49-bb05-3513fa05eb52", "a714d192-b59a-4dfe-875b-d85791512a37", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91000140-addc-4ab4-b590-a27f0afe779b", "170d9be1-40f5-4b51-9ff1-313ef0beddd8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92f775e2-dc04-4de2-a777-d7befc0f39ab", 0, new DateTime(1991, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "95c93d7d-87d4-4da9-ba24-7cbf00982a7b", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAENOg7UHa8y9DKWcTBBQNezItu8EMjOwNUAdwqB8VQ0ySeQGEoeYIXRu+suRkOY6hRA==", null, false, "b11b117e-4a02-49b6-8a50-98487953e2ce", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "92f775e2-dc04-4de2-a777-d7befc0f39ab", "26795f08-d2bb-4f49-bb05-3513fa05eb52" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91000140-addc-4ab4-b590-a27f0afe779b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "92f775e2-dc04-4de2-a777-d7befc0f39ab", "26795f08-d2bb-4f49-bb05-3513fa05eb52" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26795f08-d2bb-4f49-bb05-3513fa05eb52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92f775e2-dc04-4de2-a777-d7befc0f39ab");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba808787-0679-4ea6-b7ff-21944eae8d84", "3d414c23-cb5f-41f2-ab3b-5c990dc7bade", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c63ff628-336e-4283-b2ae-c9f6fd4dbecb", "638ea969-6ea8-422f-b63d-61c13e5e3185", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7bbf880f-7576-410f-82c7-4692648034cf", 0, "a1d073eb-ec75-4701-8c10-796304ee72cd", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEKLeqQvvgiq2MOISegYDEDQ5I1ux/GWIlcBicXGelDGXV73lXYdvqN3ecTrHoVl9NQ==", null, false, "c28ec61f-a3e6-4599-809c-cdb7d9dda8f0", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "7bbf880f-7576-410f-82c7-4692648034cf", "ba808787-0679-4ea6-b7ff-21944eae8d84" });
        }
    }
}
