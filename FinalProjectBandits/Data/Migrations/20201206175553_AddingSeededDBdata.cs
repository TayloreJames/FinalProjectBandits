using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBandits.Data.Migrations
{
    public partial class AddingSeededDBdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "City", "Email", "First_Name", "Last_Name", "MuapIndex", "Password", "Phone", "State", "Street", "UserId", "Zip" },
                values: new object[] { 1, "Detroit", null, "Betty", "White", 55.0, null, -867, "MI", "1513 Broadway", null, 0 });

            migrationBuilder.InsertData(
                table: "TaskListItems",
                columns: new[] { "Id", "Category", "CustomerID", "DatePosted", "Expiration", "Status", "TaskDescription", "TaskStartDate", "TaskTitle" },
                values: new object[] { 1, 1, 1, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "I need someone to rake my very large lawn. I'm old and can't do it.", new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rake Leaves Please" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
