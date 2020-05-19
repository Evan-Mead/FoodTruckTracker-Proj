using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class BothRolesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9f61ed5-fa71-4fc9-af23-4527c871b582");

            migrationBuilder.CreateTable(
                name: "FoodTrucks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTrucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodTrucks_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "980e7a55-90a0-4d65-b634-3f9639ad5c2f", "8f1deac9-0f9d-48c7-8ff3-22f16a71d645", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "131dbf76-4664-4363-a57f-8068a583fa2e", "387515a6-ce50-4e39-bb4b-5098916a8111", "Foodie", "FOODIE" });

            migrationBuilder.CreateIndex(
                name: "IX_FoodTrucks_IdentityUserId",
                table: "FoodTrucks",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodTrucks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "131dbf76-4664-4363-a57f-8068a583fa2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "980e7a55-90a0-4d65-b634-3f9639ad5c2f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9f61ed5-fa71-4fc9-af23-4527c871b582", "fd0e0e30-01b3-475b-ba0b-e77ca2253ab1", "Food Truck", "FOOD TRUCK" });
        }
    }
}
