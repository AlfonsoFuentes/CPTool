using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class processconditionpipng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pProcessConditionId",
                table: "PipingItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PipingItems_pProcessConditionId",
                table: "PipingItems",
                column: "pProcessConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PipingItems_ProcessConditions_pProcessConditionId",
                table: "PipingItems",
                column: "pProcessConditionId",
                principalTable: "ProcessConditions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PipingItems_ProcessConditions_pProcessConditionId",
                table: "PipingItems");

            migrationBuilder.DropIndex(
                name: "IX_PipingItems_pProcessConditionId",
                table: "PipingItems");

            migrationBuilder.DropColumn(
                name: "pProcessConditionId",
                table: "PipingItems");
        }
    }
}
