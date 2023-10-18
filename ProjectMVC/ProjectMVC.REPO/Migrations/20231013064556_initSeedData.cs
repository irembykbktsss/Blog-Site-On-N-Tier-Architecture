using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMVC.REPO.Migrations
{
    public partial class initSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Status", "SubjectName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 13, 9, 45, 56, 199, DateTimeKind.Local).AddTicks(5404), null, 1, "Programing", null },
                    { 2, new DateTime(2023, 10, 13, 9, 45, 56, 199, DateTimeKind.Local).AddTicks(5405), null, 1, "Machine Learning", null },
                    { 3, new DateTime(2023, 10, 13, 9, 45, 56, 199, DateTimeKind.Local).AddTicks(5407), null, 1, "Data Science", null },
                    { 4, new DateTime(2023, 10, 13, 9, 45, 56, 199, DateTimeKind.Local).AddTicks(5408), null, 1, "Technology", null },
                    { 5, new DateTime(2023, 10, 13, 9, 45, 56, 199, DateTimeKind.Local).AddTicks(5409), null, 1, "Politics", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
