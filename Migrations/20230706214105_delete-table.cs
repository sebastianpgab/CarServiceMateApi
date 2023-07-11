using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceMate.Migrations
{
    public partial class deletetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_CreatedById",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CreatedById",
                table: "Vehicle",
                newName: "IX_Vehicle_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ClientId",
                table: "Vehicle",
                newName: "IX_Vehicle_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Vehicle_VehicleId",
                table: "Repairs",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Clients_ClientId",
                table: "Vehicle",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Users_CreatedById",
                table: "Vehicle",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Vehicle_VehicleId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Clients_ClientId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Users_CreatedById",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_CreatedById",
                table: "Vehicles",
                newName: "IX_Vehicles_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_ClientId",
                table: "Vehicles",
                newName: "IX_Vehicles_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_CreatedById",
                table: "Vehicles",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
