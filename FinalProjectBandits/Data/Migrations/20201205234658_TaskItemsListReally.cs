using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBandits.Data.Migrations
{
    public partial class TaskItemsListReally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskListItem",
                table: "TaskListItem");

            migrationBuilder.RenameTable(
                name: "TaskListItem",
                newName: "TaskListItems");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TaskStartDate",
                table: "TaskListItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TaskListItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Expiration",
                table: "TaskListItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "TaskListItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "TaskListItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "TaskListItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskListItems",
                table: "TaskListItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskListItems_CustomerID",
                table: "TaskListItems",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskListItems_Customers_CustomerID",
                table: "TaskListItems",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskListItems_Customers_CustomerID",
                table: "TaskListItems");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskListItems",
                table: "TaskListItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskListItems_CustomerID",
                table: "TaskListItems");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "TaskListItems");

            migrationBuilder.RenameTable(
                name: "TaskListItems",
                newName: "TaskListItem");

            migrationBuilder.AlterColumn<string>(
                name: "TaskStartDate",
                table: "TaskListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TaskListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Expiration",
                table: "TaskListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "DatePosted",
                table: "TaskListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "TaskListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskListItem",
                table: "TaskListItem",
                column: "Id");
        }
    }
}
