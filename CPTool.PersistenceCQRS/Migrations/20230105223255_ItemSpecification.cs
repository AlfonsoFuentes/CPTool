using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class ItemSpecification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_MWOItems_MWOItemId",
                table: "Nozzles");

            migrationBuilder.AddColumn<int>(
                name: "MWOItemId",
                table: "PropertySpecifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertySpecifications_MWOItemId",
                table: "PropertySpecifications",
                column: "MWOItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_MWOItems_MWOItemId",
                table: "Nozzles",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertySpecifications_MWOItems_MWOItemId",
                table: "PropertySpecifications",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_MWOItems_MWOItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertySpecifications_MWOItems_MWOItemId",
                table: "PropertySpecifications");

            migrationBuilder.DropIndex(
                name: "IX_PropertySpecifications_MWOItemId",
                table: "PropertySpecifications");

            migrationBuilder.DropColumn(
                name: "MWOItemId",
                table: "PropertySpecifications");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_MWOItems_MWOItemId",
                table: "Nozzles",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");
        }
    }
}
