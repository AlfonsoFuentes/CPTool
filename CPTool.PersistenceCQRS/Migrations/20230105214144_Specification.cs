using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class Specification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentTypeId = table.Column<int>(type: "int", nullable: true),
                    EquipmentTypeSubId = table.Column<int>(type: "int", nullable: true),
                    DeviceFunctionId = table.Column<int>(type: "int", nullable: true),
                    DeviceFunctionModifierId = table.Column<int>(type: "int", nullable: true),
                    MeasuredVariableId = table.Column<int>(type: "int", nullable: true),
                    MeasuredVariableModifierId = table.Column<int>(type: "int", nullable: true),
                    ReadoutId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_DeviceFunctionModifiers_DeviceFunctionModifierId",
                        column: x => x.DeviceFunctionModifierId,
                        principalTable: "DeviceFunctionModifiers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_DeviceFunctions_DeviceFunctionId",
                        column: x => x.DeviceFunctionId,
                        principalTable: "DeviceFunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_EquipmentTypeSubs_EquipmentTypeSubId",
                        column: x => x.EquipmentTypeSubId,
                        principalTable: "EquipmentTypeSubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_EquipmentTypes_EquipmentTypeId",
                        column: x => x.EquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_MeasuredVariableModifiers_MeasuredVariableModifierId",
                        column: x => x.MeasuredVariableModifierId,
                        principalTable: "MeasuredVariableModifiers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_MeasuredVariables_MeasuredVariableId",
                        column: x => x.MeasuredVariableId,
                        principalTable: "MeasuredVariables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specifications_Readouts_ReadoutId",
                        column: x => x.ReadoutId,
                        principalTable: "Readouts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertySpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertySpecifications_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertySpecifications_SpecificationId",
                table: "PropertySpecifications",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_DeviceFunctionId",
                table: "Specifications",
                column: "DeviceFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_DeviceFunctionModifierId",
                table: "Specifications",
                column: "DeviceFunctionModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_EquipmentTypeId",
                table: "Specifications",
                column: "EquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_EquipmentTypeSubId",
                table: "Specifications",
                column: "EquipmentTypeSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_MeasuredVariableId",
                table: "Specifications",
                column: "MeasuredVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_MeasuredVariableModifierId",
                table: "Specifications",
                column: "MeasuredVariableModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ReadoutId",
                table: "Specifications",
                column: "ReadoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertySpecifications");

            migrationBuilder.DropTable(
                name: "Specifications");
        }
    }
}
