using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoStockDB.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_  DetallePlato_Ingrediente_IngredientesId",
                table: "DetallePlato");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePlato_Plato_PlatosId",
                table: "DetallePlato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallePlato",
                table: "DetallePlato");

            migrationBuilder.RenameTable(
                name: "DetallePlato",
                newName: "DetallePlato");

            migrationBuilder.RenameColumn(
                name: "IdDetalle",
                table: "DetallePlato",
                newName: "IdPlato");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePlato_PlatosId",
                table: "DetallePlato",
                newName: "IX_DetallePlato_PlatosId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePlato_IngredientesId",
                table: "DetallePlato",
                newName: "IX_DetallePlato_IngredientesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallePlato",
                table: "DetallePlato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlato_Ingrediente_IngredientesId",
                table: "DetallePlato",
                column: "IngredientesId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlato_Plato_PlatosId",
                table: "DetallePlato",
                column: "PlatosId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePlato_Ingrediente_IngredientesId",
                table: "DetallePlato");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePlato_Plato_PlatosId",
                table: "DetallePlato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallePlato",
                table: "    ");

            migrationBuilder.RenameTable(
                name: "DetallePlato",
                newName: "DetallePlato");

            migrationBuilder.RenameColumn(
                name: "IdPlato",
                table: "DetallePlato",
                newName: "IdDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePlato_PlatosId",
                table: "DetallePlato",
                newName: "IX_DetallePlato_PlatosId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePlato_IngredientesId",
                table: "DetallePlato",
                newName: "IX_DetallePlato_IngredientesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallePlato",
                table: "DetallePlato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlato_Ingrediente_IngredientesId",
                table: "DetallePlato",
                column: "IngredientesId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlato_Plato_PlatosId",
                table: "DetallePlato",
                column: "PlatosId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
