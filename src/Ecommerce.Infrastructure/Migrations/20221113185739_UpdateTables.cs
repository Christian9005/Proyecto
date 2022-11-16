using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaId1",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_MarcaId1",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "MarcaId1",
                table: "Productos");

            migrationBuilder.AlterColumn<string>(
                name: "MarcaId",
                table: "Productos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaId",
                table: "Productos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "MarcaId1",
                table: "Productos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId1",
                table: "Productos",
                column: "MarcaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaId1",
                table: "Productos",
                column: "MarcaId1",
                principalTable: "Marcas",
                principalColumn: "Id");
        }
    }
}
