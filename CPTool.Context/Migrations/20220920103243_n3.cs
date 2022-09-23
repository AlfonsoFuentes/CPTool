using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class n3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessConditions_ProcessFluids_ProcessFluidId",
                table: "ProcessConditions");

            migrationBuilder.DropIndex(
                name: "IX_ProcessConditions_ProcessFluidId",
                table: "ProcessConditions");

            migrationBuilder.DropColumn(
                name: "ProcessFluidId",
                table: "ProcessConditions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessFluidId",
                table: "ProcessConditions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessConditions_ProcessFluidId",
                table: "ProcessConditions",
                column: "ProcessFluidId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessConditions_ProcessFluids_ProcessFluidId",
                table: "ProcessConditions",
                column: "ProcessFluidId",
                principalTable: "ProcessFluids",
                principalColumn: "Id");
        }
    }
}
