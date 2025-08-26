using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KisiselBlogProjesi.Migrations
{
    /// <inheritdoc />
    public partial class Identityaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b7a61d15-5c12-4f3b-85d6-88d4c97c12f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a1b5c4f2-98e3-4d7a-b2c8-89e4a3b7d1e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c4d7e9f1-3b5a-4e2a-9f8c-1a2b3c4d5e6f");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2ea20f49-478b-4e1b-bee6-ba54e5c1788d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "12aa258a-5ae7-48c5-a0f7-88dcd60837ee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "b625f756-34ce-4b9e-b57f-b185fe43b7e3");
        }
    }
}
