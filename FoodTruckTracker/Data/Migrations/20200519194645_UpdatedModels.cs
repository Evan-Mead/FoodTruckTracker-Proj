using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTrucks",
                table: "FoodTrucks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foodies",
                table: "Foodies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c76b38b-db86-4421-bd04-72457bfdcd95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc1964bb-803e-4dc3-af14-760b3e2a08cd");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Foodies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Foodies");

            migrationBuilder.AddColumn<int>(
                name: "FoodTruckId",
                table: "FoodTrucks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FoodTruckName",
                table: "FoodTrucks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodieId",
                table: "Foodies",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FoodieName",
                table: "Foodies",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTrucks",
                table: "FoodTrucks",
                column: "FoodTruckId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foodies",
                table: "Foodies",
                column: "FoodieId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80988d3c-6f44-45e8-ba31-a96d9d21c6e5", "91706876-25b3-4978-be8b-c636d570323d", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c2e1779-680d-41d1-bb8b-9df7888616e7", "8dcf3b7a-2094-4359-be22-695ff2a988bc", "Foodie", "FOODIE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTrucks",
                table: "FoodTrucks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foodies",
                table: "Foodies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80988d3c-6f44-45e8-ba31-a96d9d21c6e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c2e1779-680d-41d1-bb8b-9df7888616e7");

            migrationBuilder.DropColumn(
                name: "FoodTruckId",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "FoodTruckName",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "FoodieId",
                table: "Foodies");

            migrationBuilder.DropColumn(
                name: "FoodieName",
                table: "Foodies");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FoodTrucks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FoodTrucks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Foodies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Foodies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTrucks",
                table: "FoodTrucks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foodies",
                table: "Foodies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc1964bb-803e-4dc3-af14-760b3e2a08cd", "cadac2ec-b540-48b3-8155-e2094d1bbcf9", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c76b38b-db86-4421-bd04-72457bfdcd95", "203cb301-3956-4fe4-8aa0-9cad6c814ff2", "Foodie", "FOODIE" });
        }
    }
}
