using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class UsrType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "UserRequirementTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "UserRequirementTypes");
        }
    }
}
