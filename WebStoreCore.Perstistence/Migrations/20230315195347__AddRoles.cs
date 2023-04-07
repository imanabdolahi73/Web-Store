using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebStoreCore.Perstistence.Migrations
{
    /// <inheritdoc />
    public partial class _AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 3, 15, 23, 23, 47, 138, DateTimeKind.Local).AddTicks(7392), false, "Admin", null, null },
                    { 2L, new DateTime(2023, 3, 15, 23, 23, 47, 138, DateTimeKind.Local).AddTicks(7540), false, "Operator", null, null },
                    { 3L, new DateTime(2023, 3, 15, 23, 23, 47, 138, DateTimeKind.Local).AddTicks(7565), false, "Customer", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
