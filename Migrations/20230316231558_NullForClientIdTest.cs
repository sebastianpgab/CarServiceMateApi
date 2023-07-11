using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceMate.Migrations
{
    public partial class NullForClientIdTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Clients_ClientId",
                table: "Vehicles",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
