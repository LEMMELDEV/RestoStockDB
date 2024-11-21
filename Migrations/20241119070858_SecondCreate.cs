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
                name: "FK_DetallesPlato_Ingrediente_IngredientesId",
                table: "DetallesPlato");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPlato_Plato_PlatosId",
                table: "DetallesPlato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesPlato",
                table: "DetallesPlato");

            migrationBuilder.RenameTable(
                name: "DetallesPlato",
                newName: "DetallesPlatos");

            migrationBuilder.RenameColumn(
                name: "IdDetalle",
                table: "DetallesPlatos",
                newName: "IdPlato");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesPlato_PlatosId",
                table: "DetallesPlatos",
                newName: "IX_DetallesPlatos_PlatosId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesPlato_IngredientesId",
                table: "DetallesPlatos",
                newName: "IX_DetallesPlatos_IngredientesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesPlatos",
                table: "DetallesPlatos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPlatos_Ingrediente_IngredientesId",
                table: "DetallesPlatos",
                column: "IngredientesId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPlatos_Plato_PlatosId",
                table: "DetallesPlatos",
                column: "PlatosId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPlatos_Ingrediente_IngredientesId",
                table: "DetallesPlatos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPlatos_Plato_PlatosId",
                table: "DetallesPlatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesPlatos",
                table: "DetallesPlatos");

            migrationBuilder.RenameTable(
                name: "DetallesPlatos",
                newName: "DetallesPlato");

            migrationBuilder.RenameColumn(
                name: "IdPlato",
                table: "DetallesPlato",
                newName: "IdDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesPlatos_PlatosId",
                table: "DetallesPlato",
                newName: "IX_DetallesPlato_PlatosId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesPlatos_IngredientesId",
                table: "DetallesPlato",
                newName: "IX_DetallesPlato_IngredientesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesPlato",
                table: "DetallesPlato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPlato_Ingrediente_IngredientesId",
                table: "DetallesPlato",
                column: "IngredientesId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPlato_Plato_PlatosId",
                table: "DetallesPlato",
                column: "PlatosId",
                principalTable: "Plato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
