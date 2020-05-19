using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruckTracker.Data.Migrations
{
    public partial class Foodie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "131dbf76-4664-4363-a57f-8068a583fa2e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "980e7a55-90a0-4d65-b634-3f9639ad5c2f");

            migrationBuilder.CreateTable(
                name: "Foodies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foodies_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc1964bb-803e-4dc3-af14-760b3e2a08cd", "cadac2ec-b540-48b3-8155-e2094d1bbcf9", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0c76b38b-db86-4421-bd04-72457bfdcd95", "203cb301-3956-4fe4-8aa0-9cad6c814ff2", "Foodie", "FOODIE" });

            migrationBuilder.CreateIndex(
                name: "IX_Foodies_IdentityUserId",
                table: "Foodies",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foodies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c76b38b-db86-4421-bd04-72457bfdcd95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc1964bb-803e-4dc3-af14-760b3e2a08cd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "980e7a55-90a0-4d65-b634-3f9639ad5c2f", "8f1deac9-0f9d-48c7-8ff3-22f16a71d645", "Food Truck", "FOOD TRUCK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "131dbf76-4664-4363-a57f-8068a583fa2e", "387515a6-ce50-4e39-bb4b-5098916a8111", "Foodie", "FOODIE" });
        }
    }
}
