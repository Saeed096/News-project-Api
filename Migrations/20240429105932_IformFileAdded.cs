using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task1.Migrations
{
    /// <inheritdoc />
    public partial class IformFileAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce48cb81-9ffb-49e3-abbf-2081f28ef835", "AQAAAAIAAYagAAAAEBu48q6jLrCWUd1y53QXHwovMQ7F3c+GjNihLXcBHN4gD/bcN+Tl6f058FTOisCEsw==", "07f28401-e6a8-4522-b8b1-815ec64af7c3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a85d1191-b523-4d9d-ae37-7d720d188fcf", "AQAAAAIAAYagAAAAEIba+wXjEefrjGTn86raST2yrnCiXupnUUTEayxPm736kO+FMYs9/DTk8sK0ZRwLqg==", "10cb729a-6b7c-4df6-b1c7-b1c932e6e5f4" });
        }
    }
}
