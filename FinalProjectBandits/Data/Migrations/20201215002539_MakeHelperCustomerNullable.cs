using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBandits.Data.Migrations
{
    public partial class MakeHelperCustomerNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HelperCustomerID",
                table: "TaskListItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "HelperCustomerID",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HelperCustomerID",
                table: "TaskListItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TaskListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "HelperCustomerID",
                value: 0);
        }
    }
}
