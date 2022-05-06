using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Infrastructure.Migrations
{
    public partial class statusAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Statuses_StatusId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_StatusId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Payments");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Statuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_PaymentId",
                table: "Statuses",
                column: "PaymentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Payments_PaymentId",
                table: "Statuses",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Payments_PaymentId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_PaymentId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Statuses");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StatusId",
                table: "Payments",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Statuses_StatusId",
                table: "Payments",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
