using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreCore.Perstistence.Migrations
{
    /// <inheritdoc />
    public partial class _Add_ViewCount_To_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 3, 25, 2, 33, 37, 984, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 3, 25, 2, 33, 37, 984, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 3, 25, 2, 33, 37, 984, DateTimeKind.Local).AddTicks(994));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 3, 16, 19, 27, 7, 270, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 3, 16, 19, 27, 7, 270, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 3, 16, 19, 27, 7, 270, DateTimeKind.Local).AddTicks(1040));
        }
    }
}
