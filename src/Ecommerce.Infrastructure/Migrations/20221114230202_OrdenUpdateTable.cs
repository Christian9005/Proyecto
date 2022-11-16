using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrdenUpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId1",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId1",
                table: "OrdenItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Productos_ProductId",
                table: "OrdenItem");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_ClienteId1",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "ProducId",
                table: "OrdenItem");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrdenItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrdenId1",
                table: "OrdenItem",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "Ordenes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteId",
                table: "Ordenes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId1",
                table: "OrdenItem",
                column: "OrdenId1",
                principalTable: "Ordenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Productos_ProductId",
                table: "OrdenItem",
                column: "ProductId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId",
                table: "Ordenes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId1",
                table: "OrdenItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenItem_Productos_ProductId",
                table: "OrdenItem");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_ClienteId",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrdenItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrdenId1",
                table: "OrdenItem",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ProducId",
                table: "OrdenItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Ordenes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId1",
                table: "Ordenes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteId1",
                table: "Ordenes",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_ClienteId1",
                table: "Ordenes",
                column: "ClienteId1",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Ordenes_OrdenId1",
                table: "OrdenItem",
                column: "OrdenId1",
                principalTable: "Ordenes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenItem_Productos_ProductId",
                table: "OrdenItem",
                column: "ProductId",
                principalTable: "Productos",
                principalColumn: "Id");
        }
    }
}
