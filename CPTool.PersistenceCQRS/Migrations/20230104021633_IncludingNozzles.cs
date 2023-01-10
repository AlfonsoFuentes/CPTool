using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class IncludingNozzles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MWOItemId",
                table: "PipeAccesorys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MWOItemId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_MWOItemId",
                table: "PipeAccesorys",
                column: "MWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_MWOItemId",
                table: "Nozzles",
                column: "MWOItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_MWOItems_MWOItemId",
                table: "Nozzles",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PipeAccesorys_MWOItems_MWOItemId",
                table: "PipeAccesorys",
                column: "MWOItemId",
                principalTable: "MWOItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_MWOItems_MWOItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_PipeAccesorys_MWOItems_MWOItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropIndex(
                name: "IX_PipeAccesorys_MWOItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_MWOItemId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "MWOItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropColumn(
                name: "MWOItemId",
                table: "Nozzles");
        }
    }
}
