using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class Update5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c3d5cc-9ee1-4289-8a15-a57729b7cd41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dca7c437-4668-4ed4-bcb9-0ac02137acc7");

            migrationBuilder.AddColumn<int>(
                name: "FoodieId",
                table: "FoodTrucks",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e40907c7-b7b4-4e26-b33a-62c303da015c", "880a601f-de2d-4bd0-8d42-2a5508d6d2ff", "FoodTruck", "FOODTRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "851f687e-a631-47c1-8f7d-df32433dc5b4", "bb86c8d1-0fba-48aa-bc9a-48c0e36bb0eb", "Foodie", "FOODIE" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodTrucks_FoodieId",
                table: "FoodTrucks",
                column: "FoodieId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTrucks_Foodies_FoodieId",
                table: "FoodTrucks",
                column: "FoodieId",
                principalTable: "Foodies",
                principalColumn: "FoodieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTrucks_Foodies_FoodieId",
                table: "FoodTrucks");

            migrationBuilder.DropIndex(
                name: "IX_FoodTrucks_FoodieId",
                table: "FoodTrucks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "851f687e-a631-47c1-8f7d-df32433dc5b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e40907c7-b7b4-4e26-b33a-62c303da015c");

            migrationBuilder.DropColumn(
                name: "FoodieId",
                table: "FoodTrucks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25c3d5cc-9ee1-4289-8a15-a57729b7cd41", "e27aa74a-75ba-4e1d-8166-8366cb4f94ed", "FoodTruck", "FOODTRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dca7c437-4668-4ed4-bcb9-0ac02137acc7", "fc60f6b9-515b-4385-957f-c493a1301bd1", "Foodie", "FOODIE" });
        }
    }
}
