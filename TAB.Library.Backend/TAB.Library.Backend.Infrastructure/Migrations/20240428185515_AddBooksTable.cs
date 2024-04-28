using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAB.Library.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAtUtc", "PublishYear", "Title", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1986, "Wiedźmin", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2003, "Diuna. Krucjata przeciw maszynom", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2016, "Behawiorysta", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2022, "Dom po drugiej stronie jeziora", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 5, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2016, "Elon Musk. Biografia twórcy PayPala, Tesli i SpaceX", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 6, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023, "Dinozaury. Encyklopedia", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 7, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023, "Historia polityczna Polski 1989-2023", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 8, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023, "Nic mnie nie złamie. Zapanuj nad swoim umysłem i pokonaj przeciwności losu", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 9, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023, "Czarek. Żołnierz Zakonu Ziemskiej Magii", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 10, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2024, "Kaczogród. Dotyk Midasa i inne historie z lat 1961–1962", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 11, 11, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023, "Zielona mila", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, 12, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2023, "Krótkie odpowiedzi na wielkie pytania", new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
