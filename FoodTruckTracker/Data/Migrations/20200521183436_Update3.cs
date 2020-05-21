using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f7035e0-6112-4a73-8827-19c16c8ee420");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f34dd2c-0436-4dd0-9a94-0a47801090ea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9e8aa91-8412-4233-ac2c-136d8aa1de3f", "76c79342-33c6-495e-9730-eb8206108db5", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f0bcb78-3072-4dd1-a0f5-6e736d42a066", "1b0a3f31-1daa-467a-846a-b1f4a9a8530c", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f0bcb78-3072-4dd1-a0f5-6e736d42a066");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9e8aa91-8412-4233-ac2c-136d8aa1de3f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f34dd2c-0436-4dd0-9a94-0a47801090ea", "ed640d75-5e03-4582-83be-6ec7544ed3e2", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f7035e0-6112-4a73-8827-19c16c8ee420", "44dd0d43-177c-4484-bf7e-c50dc571fdca", "Foodie", "FOODIE" });
        }
    }
}
