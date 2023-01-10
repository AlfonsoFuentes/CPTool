using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class nozzleconnected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConnectedToId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_ConnectedToId",
                table: "Nozzles",
                column: "ConnectedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_MWOItems_ConnectedToId",
                table: "Nozzles",
                column: "ConnectedToId",
                principalTable: "MWOItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_MWOItems_ConnectedToId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_ConnectedToId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "ConnectedToId",
                table: "Nozzles");
        }
    }
}
