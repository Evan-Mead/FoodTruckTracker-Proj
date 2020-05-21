using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "25c3d5cc-9ee1-4289-8a15-a57729b7cd41", "e27aa74a-75ba-4e1d-8166-8366cb4f94ed", "FoodTruck", "FOODTRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dca7c437-4668-4ed4-bcb9-0ac02137acc7", "fc60f6b9-515b-4385-957f-c493a1301bd1", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c3d5cc-9ee1-4289-8a15-a57729b7cd41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dca7c437-4668-4ed4-bcb9-0ac02137acc7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9e8aa91-8412-4233-ac2c-136d8aa1de3f", "76c79342-33c6-495e-9730-eb8206108db5", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f0bcb78-3072-4dd1-a0f5-6e736d42a066", "1b0a3f31-1daa-467a-846a-b1f4a9a8530c", "Foodie", "FOODIE" });
        }
    }
}
