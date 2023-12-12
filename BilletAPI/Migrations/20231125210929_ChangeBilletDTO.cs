using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilletAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBilletDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 23, 9, 29, 6, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 23, 9, 29, 6, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 23, 9, 29, 6, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 23, 9, 29, 6, DateTimeKind.Local).AddTicks(9317));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 22, 37, 26, 458, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 22, 37, 26, 458, DateTimeKind.Local).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 22, 37, 26, 458, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 25, 22, 37, 26, 458, DateTimeKind.Local).AddTicks(9798));
        }
    }
}
