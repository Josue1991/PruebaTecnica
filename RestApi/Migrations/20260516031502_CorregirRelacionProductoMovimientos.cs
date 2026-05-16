using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi.Migrations
{
    /// <inheritdoc />
    public partial class CorregirRelacionProductoMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockMovements",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "MovimientosStock",
                newName: "Tipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "MovimientosStock",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "StockMovements",
                table: "Productos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
