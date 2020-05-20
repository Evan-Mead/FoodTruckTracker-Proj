using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class UpdatedModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80988d3c-6f44-45e8-ba31-a96d9d21c6e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c2e1779-680d-41d1-bb8b-9df7888616e7");

            migrationBuilder.AddColumn<string>(
                name: "CuisineType",
                table: "FoodTrucks",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "FoodTrucks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "FoodTrucks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProfileViews",
                table: "FoodTrucks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TruckCrew",
                table: "FoodTrucks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TruckHistory",
                table: "FoodTrucks",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f34dd2c-0436-4dd0-9a94-0a47801090ea", "ed640d75-5e03-4582-83be-6ec7544ed3e2", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f7035e0-6112-4a73-8827-19c16c8ee420", "44dd0d43-177c-4484-bf7e-c50dc571fdca", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f7035e0-6112-4a73-8827-19c16c8ee420");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f34dd2c-0436-4dd0-9a94-0a47801090ea");

            migrationBuilder.DropColumn(
                name: "CuisineType",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "ProfileViews",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "TruckCrew",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "TruckHistory",
                table: "FoodTrucks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80988d3c-6f44-45e8-ba31-a96d9d21c6e5", "91706876-25b3-4978-be8b-c636d570323d", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c2e1779-680d-41d1-bb8b-9df7888616e7", "8dcf3b7a-2094-4359-be22-695ff2a988bc", "Foodie", "FOODIE" });
        }
    }
}
