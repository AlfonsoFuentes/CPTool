using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class TestMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Materials_OuterMaterialId",
                table: "MWOItems");

            migrationBuilder.RenameColumn(
                name: "OuterMaterialId",
                table: "MWOItems",
                newName: "MaterialOuterId");

            migrationBuilder.RenameIndex(
                name: "IX_MWOItems_OuterMaterialId",
                table: "MWOItems",
                newName: "IX_MWOItems_MaterialOuterId");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Materials_MaterialOuterId",
                table: "MWOItems",
                column: "MaterialOuterId",
                principalTable: "Materials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Materials_MaterialOuterId",
                table: "MWOItems");

            migrationBuilder.RenameColumn(
                name: "MaterialOuterId",
                table: "MWOItems",
                newName: "OuterMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_MWOItems_MaterialOuterId",
                table: "MWOItems",
                newName: "IX_MWOItems_OuterMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Materials_OuterMaterialId",
                table: "MWOItems",
                column: "OuterMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }
    }
}
