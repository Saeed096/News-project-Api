using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task1.Migrations
{
    /// <inheritdoc />
    public partial class addNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a85d1191-b523-4d9d-ae37-7d720d188fcf", "AQAAAAIAAYagAAAAEIba+wXjEefrjGTn86raST2yrnCiXupnUUTEayxPm736kO+FMYs9/DTk8sK0ZRwLqg==", "10cb729a-6b7c-4df6-b1c7-b1c932e6e5f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "857b5200-58d4-4456-ae37-2733c64bbaa8", "AQAAAAIAAYagAAAAEOhdJ+84z5lwKB2uYhPxDVnarXP8p77M84hRpCHbPKKP8bC26tXIpCsys61B0alg/g==", "fce2c432-5a09-45a6-8512-f5ce34da4a22" });
        }
    }
}
