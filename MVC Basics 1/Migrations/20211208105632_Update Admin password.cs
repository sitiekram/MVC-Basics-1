using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Basics_1.Migrations
{
    public partial class UpdateAdminpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
