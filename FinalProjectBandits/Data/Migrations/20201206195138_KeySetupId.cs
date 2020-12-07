using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBandits.Data.Migrations
{
    public partial class KeySetupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                column: "Phone",
                value: "313-300-0880");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "City", "Email", "First_Name", "Last_Name", "MuapIndex", "Password", "Phone", "State", "Street", "UserId", "Zip" },
                values: new object[,]
                {
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

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                column: "Phone",
                value: -867);
        }
    }
}
