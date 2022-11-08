using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.Infrastructure.Migrations
{
    public partial class controlloop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlLoops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlLoopType = table.Column<int>(type: "int", nullable: false),
                    ProcessVariableId = table.Column<int>(type: "int", nullable: true),
                    ControlledVariableId = table.Column<int>(type: "int", nullable: true),
                    PTerm = table.Column<double>(type: "float", nullable: false),
                    ITerm = table.Column<double>(type: "float", nullable: false),
                    DTerm = table.Column<double>(type: "float", nullable: false),
                    ProcessVariableMinId = table.Column<int>(type: "int", nullable: true),
                    ProcessVariableMaxId = table.Column<int>(type: "int", nullable: true),
                    ProcessVariableValueId = table.Column<int>(type: "int", nullable: true),
                    ControlledVariableMin = table.Column<double>(type: "float", nullable: false),
                    ControlledVariableMax = table.Column<double>(type: "float", nullable: false),
                    ControlledVariableValue = table.Column<double>(type: "float", nullable: false),
                    SPId = table.Column<int>(type: "int", nullable: true),
                    PVRange = table.Column<double>(type: "float", nullable: false),
                    WindupGuard = table.Column<double>(type: "float", nullable: false),
                    ManualOverride = table.Column<bool>(type: "bit", nullable: false),
                    DirectActing = table.Column<bool>(type: "bit", nullable: false),
                    FailClose = table.Column<bool>(type: "bit", nullable: false),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlLoops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlLoops_Signals_ControlledVariableId",
                        column: x => x.ControlledVariableId,
                        principalTable: "Signals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlLoops_Signals_ProcessVariableId",
                        column: x => x.ProcessVariableId,
                        principalTable: "Signals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlLoops_Units_ProcessVariableMaxId",
                        column: x => x.ProcessVariableMaxId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlLoops_Units_ProcessVariableMinId",
                        column: x => x.ProcessVariableMinId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlLoops_Units_ProcessVariableValueId",
                        column: x => x.ProcessVariableValueId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControlLoops_Units_SPId",
                        column: x => x.SPId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_ControlledVariableId",
                table: "ControlLoops",
                column: "ControlledVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_ProcessVariableId",
                table: "ControlLoops",
                column: "ProcessVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_ProcessVariableMaxId",
                table: "ControlLoops",
                column: "ProcessVariableMaxId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_ProcessVariableMinId",
                table: "ControlLoops",
                column: "ProcessVariableMinId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_ProcessVariableValueId",
                table: "ControlLoops",
                column: "ProcessVariableValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_SPId",
                table: "ControlLoops",
                column: "SPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlLoops");
        }
    }
}
