using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceMate.Migrations
{
    public partial class delete_entity_notification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Notifications_NotificationId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_NotificationId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "Repairs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "Repairs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_NotificationId",
                table: "Repairs",
                column: "NotificationId",
                unique: true,
                filter: "[NotificationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Notifications_NotificationId",
                table: "Repairs",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
