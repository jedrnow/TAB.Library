using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAB.Library.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAtUtc", "FirstName", "LastName", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrzej", "Sapkowski", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian", "Herbert", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Remigiusz", "Mróz", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riley", "Sager", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vance", "Ashlee", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dougal", "Dixon", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antoni", "Dudek", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Goggins", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marek", "Wnukowski", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carl", "Barks", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen", "King", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen", "Hawking", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
