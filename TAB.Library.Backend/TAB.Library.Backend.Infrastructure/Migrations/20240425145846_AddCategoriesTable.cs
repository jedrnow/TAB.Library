using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAB.Library.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science fiction", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kryminał", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thriller", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biografia", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Encyklopedia", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historia", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poradnik", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bajka", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Komiks", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Horror", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Popularnonaukowa", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1168), new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1172) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1173), new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAtUtc", "UpdatedAtUtc" },
                values: new object[] { new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(3946), new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(3948) });
        }
    }
}
