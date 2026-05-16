using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarTablasAEspanol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_Products_ProductId",
                table: "StockMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockMovements",
                table: "StockMovements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "StockMovements",
                newName: "MovimientosStock");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Productos");

            migrationBuilder.RenameIndex(
                name: "IX_StockMovements_ProductId",
                table: "MovimientosStock",
                newName: "IX_MovimientosStock_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Codigo",
                table: "Productos",
                newName: "IX_Productos_Codigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovimientosStock",
                table: "MovimientosStock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_Productos_ProductId",
                table: "MovimientosStock",
                column: "ProductId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_Productos_ProductId",
                table: "MovimientosStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovimientosStock",
                table: "MovimientosStock");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "MovimientosStock",
                newName: "StockMovements");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_Codigo",
                table: "Products",
                newName: "IX_Products_Codigo");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientosStock_ProductId",
                table: "StockMovements",
                newName: "IX_StockMovements_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockMovements",
                table: "StockMovements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_Products_ProductId",
                table: "StockMovements",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
