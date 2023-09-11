using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceMate.Migrations
{
    public partial class add_ComapanyEntity_and_ids_to_Others : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "SmsRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Repairs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "MailRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "SmsRequests");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "MailRequests");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Clients");
        }
    }
}
