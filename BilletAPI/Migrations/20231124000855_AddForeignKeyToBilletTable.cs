using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilletAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToBilletTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BilletId",
                table: "BilletUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 2, 8, 55, 442, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 2, 8, 55, 442, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 2, 8, 55, 442, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 24, 2, 8, 55, 442, DateTimeKind.Local).AddTicks(7533));

            migrationBuilder.CreateIndex(
                name: "IX_BilletUsers_BilletId",
                table: "BilletUsers",
                column: "BilletId");

            migrationBuilder.AddForeignKey(
                name: "FK_BilletUsers_Billets_BilletId",
                table: "BilletUsers",
                column: "BilletId",
                principalTable: "Billets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BilletUsers_Billets_BilletId",
                table: "BilletUsers");

            migrationBuilder.DropIndex(
                name: "IX_BilletUsers_BilletId",
                table: "BilletUsers");

            migrationBuilder.DropColumn(
                name: "BilletId",
                table: "BilletUsers");

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(538));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 22, 22, 26, 2, 665, DateTimeKind.Local).AddTicks(544));
        }
    }
}
