using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrdenItemUpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId1",
                table: "OrdenItem");

            migrationBuilder.DropIndex(
                name: "IX_OrdenItem_OrdenId1",
                table: "OrdenItem");

            migrationBuilder.DropColumn(
                name: "OrdenId1",
                table: "OrdenItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrdenId",
                table: "OrdenItem",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItem_OrdenId",
                table: "OrdenItem",
                column: "OrdenId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId",
                table: "OrdenItem",
                column: "OrdenId",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId",
                table: "OrdenItem");

            migrationBuilder.DropIndex(
                name: "IX_OrdenItem_OrdenId",
                table: "OrdenItem");

            migrationBuilder.AlterColumn<int>(
                name: "OrdenId",
                table: "OrdenItem",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "OrdenId1",
                table: "OrdenItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItem_OrdenId1",
                table: "OrdenItem",
                column: "OrdenId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId1",
                table: "OrdenItem",
                column: "OrdenId1",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
