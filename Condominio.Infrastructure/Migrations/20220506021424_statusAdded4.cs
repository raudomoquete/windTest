using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Infrastructure.Migrations
{
    public partial class statusAdded4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Payments_PaymentId",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Stats");

            migrationBuilder.RenameIndex(
                name: "IX_Statuses_PaymentId",
                table: "Stats",
                newName: "IX_Stats_PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stats",
                table: "Stats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_Payments_PaymentId",
                table: "Stats",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stats_Payments_PaymentId",
                table: "Stats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stats",
                table: "Stats");

            migrationBuilder.RenameTable(
                name: "Stats",
                newName: "Statuses");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_PaymentId",
                table: "Statuses",
                newName: "IX_Statuses_PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Payments_PaymentId",
                table: "Statuses",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
