using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Context.Migrations
{
    public partial class materialgropuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialsGrouptId",
                table: "EquipmentItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialsGrouptId",
                table: "EquipmentItems",
                type: "int",
                nullable: true);
        }
    }
}
