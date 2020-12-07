using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBandits.Data.Migrations
{
    public partial class UpdateFirst3Customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "City", "Email", "First_Name", "Last_Name", "MuapIndex", "Password", "Phone", "State", "Street", "UserId", "Zip" },
                values: new object[,]
                {
                    { 1, "Detroit", null, "Betty", "White", 55.0, null, "313-300-0880", "MI", "1513 Broadway", null, 0 },
                    { 2, "Detroit", null, "Ann", "Dombrowski", 45.0, null, "313-555-1212", "MI", "1 Woodward", null, 0 },
                    { 3, "Detroit", null, "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", null, 0 },
                    { 4, "Detroit", null, "Dennis", "Shire", 65.0, null, "313-777-3212", "MI", "1416 Woodward", null, 0 },
                    { 5, "Detroit", null, "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", null, 0 },
                    { 6, "Detroit", null, "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", null, 0 },
                    { 7, "Detroit", null, "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", null, 0 },
                    { 8, "Detroit", null, "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", null, 0 },
                    { 9, "Detroit", null, "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", null, 0 },
                    { 10, "Detroit", null, "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "TaskListItems",
                columns: new[] { "Id", "Category", "CustomerID", "DatePosted", "Expiration", "Status", "TaskDescription", "TaskStartDate", "TaskTitle" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "I need someone to rake my very large lawn. I'm old and can't do it.", new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rake Leaves Please" });
        }
    }
}
