using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class controlloop3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MWOId",
                table: "ControlLoops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_MWOId",
                table: "ControlLoops",
                column: "MWOId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlLoops_MWOs_MWOId",
                table: "ControlLoops",
                column: "MWOId",
                principalTable: "MWOs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlLoops_MWOs_MWOId",
                table: "ControlLoops");

            migrationBuilder.DropIndex(
                name: "IX_ControlLoops_MWOId",
                table: "ControlLoops");

            migrationBuilder.DropColumn(
                name: "MWOId",
                table: "ControlLoops");
        }
    }
}
