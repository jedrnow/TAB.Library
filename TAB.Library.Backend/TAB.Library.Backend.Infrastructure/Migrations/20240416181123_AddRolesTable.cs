using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TAB.Library.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
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
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAtUtc", "Name", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1168), "Administrator", new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1172) },
                    { 2, new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1173), "User", new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(1173) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAtUtc", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UpdatedAtUtc", "Username" },
                values: new object[] { 1, new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(3946), "jedrzej.nowaczyk00@gmail.com", "Jędrzej", "Nowaczyk", "7d948a6a6ea2e89d89645321e2df20d7ad859e7008acb8531f295b05f59b9a98", "1234567890", 1, new DateTime(2024, 4, 16, 18, 11, 22, 601, DateTimeKind.Utc).AddTicks(3948), "superadmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");
        }
    }
}
