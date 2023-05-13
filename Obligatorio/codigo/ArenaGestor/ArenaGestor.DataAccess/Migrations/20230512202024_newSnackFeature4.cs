using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArenaGestor.DataAccess.Migrations
{
    public partial class newSnackFeature4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SnackBuy_Ticket_TicketId1",
                table: "SnackBuy");

            migrationBuilder.DropIndex(
                name: "IX_SnackBuy_TicketId1",
                table: "SnackBuy");

            migrationBuilder.DropColumn(
                name: "TicketId1",
                table: "SnackBuy");

            migrationBuilder.AlterColumn<Guid>(
                name: "TicketId",
                table: "SnackBuy",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SnackBuy_TicketId",
                table: "SnackBuy",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_SnackBuy_Ticket_TicketId",
                table: "SnackBuy",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SnackBuy_Ticket_TicketId",
                table: "SnackBuy");

            migrationBuilder.DropIndex(
                name: "IX_SnackBuy_TicketId",
                table: "SnackBuy");

            migrationBuilder.AlterColumn<string>(
                name: "TicketId",
                table: "SnackBuy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId1",
                table: "SnackBuy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SnackBuy_TicketId1",
                table: "SnackBuy",
                column: "TicketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SnackBuy_Ticket_TicketId1",
                table: "SnackBuy",
                column: "TicketId1",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
