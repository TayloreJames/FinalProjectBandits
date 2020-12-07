using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBandits.Data.Migrations
{
    public partial class MovingDataBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "City", "Email", "First_Name", "Last_Name", "MuapIndex", "Password", "Phone", "State", "Street", "UserId", "Zip" },
                values: new object[] { 1, "Detroit", "sandyisgreat@gmail.com", "Betty", "White", 55.0, null, "313-300-0880", "MI", "1513 Broadway", "6f304f04-0620-4ea4-b969-545b3152a700", 48226 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "City", "Email", "First_Name", "Last_Name", "MuapIndex", "Password", "Phone", "State", "Street", "UserId", "Zip" },
                values: new object[] { 2, "Detroit", "sendmemail@gmail.com", "Ann", "Dombrowski", 45.0, null, "313-555-1212", "MI", "1 Woodward", "0f1e3768-39ba-4e08-8892-ab2e60db27da", 48226 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "City", "Email", "First_Name", "Last_Name", "MuapIndex", "Password", "Phone", "State", "Street", "UserId", "Zip" },
                values: new object[] { 3, "Detroit", "sendm@gmail.com", "Chuck", "Norris", 35.0, null, "313-666-1212", "MI", "2346 Woodward", "0d8258fb-d79a-47f9-80c1-f93dc8ff1ea6", 48226 });

            migrationBuilder.InsertData(
                table: "TaskListItems",
                columns: new[] { "Id", "Category", "CustomerID", "DatePosted", "Expiration", "Status", "TaskDescription", "TaskStartDate", "TaskTitle" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "I need someone to rake my very large lawn. I'm old and can't do it.", new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rake Leaves Please" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
