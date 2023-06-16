using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurakNews.Repository.Migrations
{
    public partial class NewComputerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5356), new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5358), new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5357) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5360), new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5474), new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5473) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5476), new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5475) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5477), new DateTime(2023, 4, 28, 18, 43, 55, 70, DateTimeKind.Local).AddTicks(5477) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3049), new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3045) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3051), new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3053), new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3052) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3200), new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3199) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3202), new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3201) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3203), new DateTime(2023, 4, 26, 14, 18, 40, 271, DateTimeKind.Local).AddTicks(3203) });
        }
    }
}
