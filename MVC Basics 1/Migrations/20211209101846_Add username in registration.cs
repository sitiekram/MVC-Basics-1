using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class Addusernameinregistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87c1914a-0645-4c61-bc78-925737749ddd", "142fcecb-fde1-40fc-a564-502675fd1ca4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6aea93fa-4c21-4ac2-83af-6e53787a194a", "1824bd35-aaf7-47d5-b462-f537d41121c4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f993d9f3-9190-4c36-966d-de8d2b8c2227", 0, new DateTime(1991, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "41853483-4143-495f-8cf8-1e4df6c25e0d", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEGcYIU1CHhhos5cp5H48t//4to50aehdhQ3fu939f7Ha5RH47DFzcKbeuRdkzscrYw==", null, false, "c640b149-f1dd-47cf-bebb-b782d86fdb17", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "f993d9f3-9190-4c36-966d-de8d2b8c2227", "87c1914a-0645-4c61-bc78-925737749ddd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6aea93fa-4c21-4ac2-83af-6e53787a194a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "f993d9f3-9190-4c36-966d-de8d2b8c2227", "87c1914a-0645-4c61-bc78-925737749ddd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87c1914a-0645-4c61-bc78-925737749ddd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f993d9f3-9190-4c36-966d-de8d2b8c2227");

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
    }
}
