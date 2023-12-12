using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilletAPI.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalUsers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 3, 21, 37, 19, 255, DateTimeKind.Local).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 3, 21, 37, 19, 255, DateTimeKind.Local).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 3, 21, 37, 19, 255, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 3, 21, 37, 19, 255, DateTimeKind.Local).AddTicks(5213));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalUsers");

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 33, 19, 387, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 33, 19, 387, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 33, 19, 387, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "Billets",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 29, 0, 33, 19, 387, DateTimeKind.Local).AddTicks(1376));
        }
    }
}
