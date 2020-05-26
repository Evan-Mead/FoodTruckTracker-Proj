using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class Update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "851f687e-a631-47c1-8f7d-df32433dc5b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e40907c7-b7b4-4e26-b33a-62c303da015c");

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    FoodTruckId = table.Column<int>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_FoodTrucks_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTrucks",
                        principalColumn: "FoodTruckId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "514d2b34-1c5f-45fb-bfe0-380bf6f467a5", "22677295-ddf7-4519-9531-219818bebf17", "FoodTruck", "FOODTRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f6b35fb-2e81-466f-a735-4d4fcaa8c9c0", "ddfdb0cf-e1fd-4e15-8f5a-7f338043440c", "Foodie", "FOODIE" });

            migrationBuilder.CreateIndex(
                name: "IX_Review_FoodTruckId",
                table: "Review",
                column: "FoodTruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_IdentityUserId",
                table: "Review",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f6b35fb-2e81-466f-a735-4d4fcaa8c9c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "514d2b34-1c5f-45fb-bfe0-380bf6f467a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e40907c7-b7b4-4e26-b33a-62c303da015c", "880a601f-de2d-4bd0-8d42-2a5508d6d2ff", "FoodTruck", "FOODTRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "851f687e-a631-47c1-8f7d-df32433dc5b4", "bb86c8d1-0fba-48aa-bc9a-48c0e36bb0eb", "Foodie", "FOODIE" });
        }
    }
}
