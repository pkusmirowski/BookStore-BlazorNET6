using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class SeededDefaultUserandRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0350d2b3-faa0-4c0a-96b6-b0b4575d544a", "57b9f93b-4347-49df-863c-2f3a62460e59", "User", "USER" },
                    { "a11d9354-185d-47c0-a6b9-e39ae042b338", "0cf09233-39dd-4aab-9e5e-896cffd96973", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0350d2b3-faa0-4c0a-96b6-b0b4575d544a", 0, "66dfc5d9-9fd1-4928-84e5-b876e3b3a389", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAECuD2gPSJWWjKCTWfsGj8KxsKlI+/peo5x7EOXhddMuvbUMzjv7jg9VtERQZuxDzQA==", null, false, "17639c66-bf35-4cb7-a4e1-a8de1b1b06c0", false, "admin@bookstore.com" },
                    { "a11d9354-185d-47c0-a6b9-e39ae042b338", 0, "fa9eb3be-817e-4749-8c00-34a905204456", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEH9ruOncaBMJlFkKO+gLMOxLs6TbHtDpbweClzrZECUKxr71XJLtfzMr1+P7HL7fTQ==", null, false, "f0a37c38-effb-4ffe-8028-1ce491d5d848", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0350d2b3-faa0-4c0a-96b6-b0b4575d544a", "0350d2b3-faa0-4c0a-96b6-b0b4575d544a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a11d9354-185d-47c0-a6b9-e39ae042b338", "a11d9354-185d-47c0-a6b9-e39ae042b338" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0350d2b3-faa0-4c0a-96b6-b0b4575d544a", "0350d2b3-faa0-4c0a-96b6-b0b4575d544a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a11d9354-185d-47c0-a6b9-e39ae042b338", "a11d9354-185d-47c0-a6b9-e39ae042b338" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0350d2b3-faa0-4c0a-96b6-b0b4575d544a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a11d9354-185d-47c0-a6b9-e39ae042b338");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0350d2b3-faa0-4c0a-96b6-b0b4575d544a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a11d9354-185d-47c0-a6b9-e39ae042b338");
        }
    }
}
