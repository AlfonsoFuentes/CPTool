using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class projectLeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedByUserId",
                table: "UserRequirements");

            migrationBuilder.DropColumn(
                name: "ProjectLeader",
                table: "MWOs");

            migrationBuilder.AddColumn<bool>(
                name: "IsTwoWayMatch",
                table: "TaxCodeLDs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProjectLeaderId",
                table: "MWOs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MWOs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MWOs_UserId",
                table: "MWOs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOs_Users_UserId",
                table: "MWOs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOs_Users_UserId",
                table: "MWOs");

            migrationBuilder.DropIndex(
                name: "IX_MWOs_UserId",
                table: "MWOs");

            migrationBuilder.DropColumn(
                name: "IsTwoWayMatch",
                table: "TaxCodeLDs");

            migrationBuilder.DropColumn(
                name: "ProjectLeaderId",
                table: "MWOs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MWOs");

            migrationBuilder.AddColumn<int>(
                name: "RequestedByUserId",
                table: "UserRequirements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectLeader",
                table: "MWOs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
