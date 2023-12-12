using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilletAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMaxLengthBillet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 12, 9, 850, DateTimeKind.Local).AddTicks(8079));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
