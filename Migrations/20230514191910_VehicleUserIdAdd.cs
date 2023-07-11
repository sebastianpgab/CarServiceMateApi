using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceMate.Migrations
{
    public partial class VehicleUserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Vehicles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CreatedById",
                table: "Vehicles",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_CreatedById",
                table: "Vehicles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_CreatedById",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CreatedById",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Vehicles");
        }
    }
}
