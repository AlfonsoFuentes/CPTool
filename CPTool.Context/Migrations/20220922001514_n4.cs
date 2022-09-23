using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class n4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Chapters_ChapterId",
                table: "MWOItems");

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "MWOItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Chapters_ChapterId",
                table: "MWOItems",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_Chapters_ChapterId",
                table: "MWOItems");

            migrationBuilder.AlterColumn<int>(
                name: "ChapterId",
                table: "MWOItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_Chapters_ChapterId",
                table: "MWOItems",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
