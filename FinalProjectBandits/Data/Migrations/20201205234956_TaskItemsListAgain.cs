using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBandits.Data.Migrations
{
    public partial class TaskItemsListAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MuapIndex",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MuapIndex",
                table: "Customers");
        }
    }
}
