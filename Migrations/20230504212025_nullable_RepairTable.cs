using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceMate.Migrations
{
    public partial class nullable_RepairTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Orders_OrderId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_OrderId",
                table: "Repairs");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Repairs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Repairs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_OrderId",
                table: "Repairs",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Orders_OrderId",
                table: "Repairs",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Orders_OrderId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_OrderId",
                table: "Repairs");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_OrderId",
                table: "Repairs",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Orders_OrderId",
                table: "Repairs",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Vehicles_VehicleId",
                table: "Repairs",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
