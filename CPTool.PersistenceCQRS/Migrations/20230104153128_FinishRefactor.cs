using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTool.PersistenceCQRS.Migrations
{
    /// <inheritdoc />
    public partial class FinishRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_EquipmentItem_EquipmentItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_InstrumentItem_InstrumentItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MWOItems_PipingItem_PipingItemId",
                table: "MWOItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_EquipmentItem_EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_InstrumentItem_InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_Nozzles_PipingItem_PipingItemId",
                table: "Nozzles");

            migrationBuilder.DropForeignKey(
                name: "FK_PipeAccesorys_PipingItem_pPipingItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropTable(
                name: "EquipmentItem");

            migrationBuilder.DropTable(
                name: "InstrumentItem");

            migrationBuilder.DropTable(
                name: "PipingItem");

            migrationBuilder.DropIndex(
                name: "IX_PipeAccesorys_pPipingItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_Nozzles_PipingItemId",
                table: "Nozzles");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_EquipmentItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_InstrumentItemId",
                table: "MWOItems");

            migrationBuilder.DropIndex(
                name: "IX_MWOItems_PipingItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "pPipingItemId",
                table: "PipeAccesorys");

            migrationBuilder.DropColumn(
                name: "EquipmentItemId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "InstrumentItemId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "PipingItemId",
                table: "Nozzles");

            migrationBuilder.DropColumn(
                name: "EquipmentItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "InstrumentItemId",
                table: "MWOItems");

            migrationBuilder.DropColumn(
                name: "PipingItemId",
                table: "MWOItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pPipingItemId",
                table: "PipeAccesorys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentItemId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentItemId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PipingItemId",
                table: "Nozzles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PipingItemId",
                table: "MWOItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eBrandId = table.Column<int>(type: "int", nullable: true),
                    eEquipmentTypeId = table.Column<int>(type: "int", nullable: true),
                    eEquipmentTypeSubId = table.Column<int>(type: "int", nullable: true),
                    eGasketId = table.Column<int>(type: "int", nullable: true),
                    eInnerMaterialId = table.Column<int>(type: "int", nullable: true),
                    eOuterMaterialId = table.Column<int>(type: "int", nullable: true),
                    eProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    eProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    eSupplierId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentItem_Brands_eBrandId",
                        column: x => x.eBrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_EquipmentTypeSubs_eEquipmentTypeSubId",
                        column: x => x.eEquipmentTypeSubId,
                        principalTable: "EquipmentTypeSubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_EquipmentTypes_eEquipmentTypeId",
                        column: x => x.eEquipmentTypeId,
                        principalTable: "EquipmentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_Gaskets_eGasketId",
                        column: x => x.eGasketId,
                        principalTable: "Gaskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_Materials_eInnerMaterialId",
                        column: x => x.eInnerMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_Materials_eOuterMaterialId",
                        column: x => x.eOuterMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_ProcessConditions_eProcessConditionId",
                        column: x => x.eProcessConditionId,
                        principalTable: "ProcessConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_ProcessFluids_eProcessFluidId",
                        column: x => x.eProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentItem_Suppliers_eSupplierId",
                        column: x => x.eSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstrumentItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceFunctionId = table.Column<int>(type: "int", nullable: true),
                    DeviceFunctionModifierId = table.Column<int>(type: "int", nullable: true),
                    iBrandId = table.Column<int>(type: "int", nullable: true),
                    iGasketId = table.Column<int>(type: "int", nullable: true),
                    iInnerMaterialId = table.Column<int>(type: "int", nullable: true),
                    iOuterMaterialId = table.Column<int>(type: "int", nullable: true),
                    iProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    iProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    iSupplierId = table.Column<int>(type: "int", nullable: true),
                    MeasuredVariableId = table.Column<int>(type: "int", nullable: true),
                    MeasuredVariableModifierId = table.Column<int>(type: "int", nullable: true),
                    ReadoutId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentItem_Brands_iBrandId",
                        column: x => x.iBrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_DeviceFunctionModifiers_DeviceFunctionModifierId",
                        column: x => x.DeviceFunctionModifierId,
                        principalTable: "DeviceFunctionModifiers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_DeviceFunctions_DeviceFunctionId",
                        column: x => x.DeviceFunctionId,
                        principalTable: "DeviceFunctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_Gaskets_iGasketId",
                        column: x => x.iGasketId,
                        principalTable: "Gaskets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_Materials_iInnerMaterialId",
                        column: x => x.iInnerMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_Materials_iOuterMaterialId",
                        column: x => x.iOuterMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_MeasuredVariableModifiers_MeasuredVariableModifierId",
                        column: x => x.MeasuredVariableModifierId,
                        principalTable: "MeasuredVariableModifiers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_MeasuredVariables_MeasuredVariableId",
                        column: x => x.MeasuredVariableId,
                        principalTable: "MeasuredVariables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_ProcessConditions_iProcessConditionId",
                        column: x => x.iProcessConditionId,
                        principalTable: "ProcessConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_ProcessFluids_iProcessFluidId",
                        column: x => x.iProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_Readouts_ReadoutId",
                        column: x => x.ReadoutId,
                        principalTable: "Readouts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstrumentItem_Suppliers_iSupplierId",
                        column: x => x.iSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PipingItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinishMWOItemId = table.Column<int>(type: "int", nullable: true),
                    NozzleFinishId = table.Column<int>(type: "int", nullable: true),
                    NozzleStartId = table.Column<int>(type: "int", nullable: true),
                    pDiameterId = table.Column<int>(type: "int", nullable: true),
                    pMaterialId = table.Column<int>(type: "int", nullable: true),
                    pPipeClassId = table.Column<int>(type: "int", nullable: true),
                    pProcessConditionId = table.Column<int>(type: "int", nullable: true),
                    pProcessFluidId = table.Column<int>(type: "int", nullable: true),
                    StartMWOItemId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insulation = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipingItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PipingItem_MWOItems_FinishMWOItemId",
                        column: x => x.FinishMWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_MWOItems_StartMWOItemId",
                        column: x => x.StartMWOItemId,
                        principalTable: "MWOItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_Materials_pMaterialId",
                        column: x => x.pMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_Nozzles_NozzleFinishId",
                        column: x => x.NozzleFinishId,
                        principalTable: "Nozzles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_Nozzles_NozzleStartId",
                        column: x => x.NozzleStartId,
                        principalTable: "Nozzles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_PipeClasss_pPipeClassId",
                        column: x => x.pPipeClassId,
                        principalTable: "PipeClasss",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_PipeDiameters_pDiameterId",
                        column: x => x.pDiameterId,
                        principalTable: "PipeDiameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_ProcessConditions_pProcessConditionId",
                        column: x => x.pProcessConditionId,
                        principalTable: "ProcessConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PipingItem_ProcessFluids_pProcessFluidId",
                        column: x => x.pProcessFluidId,
                        principalTable: "ProcessFluids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PipeAccesorys_pPipingItemId",
                table: "PipeAccesorys",
                column: "pPipingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_EquipmentItemId",
                table: "Nozzles",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_InstrumentItemId",
                table: "Nozzles",
                column: "InstrumentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Nozzles_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_EquipmentItemId",
                table: "MWOItems",
                column: "EquipmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_InstrumentItemId",
                table: "MWOItems",
                column: "InstrumentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MWOItems_PipingItemId",
                table: "MWOItems",
                column: "PipingItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eBrandId",
                table: "EquipmentItem",
                column: "eBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eEquipmentTypeId",
                table: "EquipmentItem",
                column: "eEquipmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eEquipmentTypeSubId",
                table: "EquipmentItem",
                column: "eEquipmentTypeSubId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eGasketId",
                table: "EquipmentItem",
                column: "eGasketId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eInnerMaterialId",
                table: "EquipmentItem",
                column: "eInnerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eOuterMaterialId",
                table: "EquipmentItem",
                column: "eOuterMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eProcessConditionId",
                table: "EquipmentItem",
                column: "eProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eProcessFluidId",
                table: "EquipmentItem",
                column: "eProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentItem_eSupplierId",
                table: "EquipmentItem",
                column: "eSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_DeviceFunctionId",
                table: "InstrumentItem",
                column: "DeviceFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_DeviceFunctionModifierId",
                table: "InstrumentItem",
                column: "DeviceFunctionModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_iBrandId",
                table: "InstrumentItem",
                column: "iBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_iGasketId",
                table: "InstrumentItem",
                column: "iGasketId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_iInnerMaterialId",
                table: "InstrumentItem",
                column: "iInnerMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_iOuterMaterialId",
                table: "InstrumentItem",
                column: "iOuterMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_iProcessConditionId",
                table: "InstrumentItem",
                column: "iProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_iProcessFluidId",
                table: "InstrumentItem",
                column: "iProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_iSupplierId",
                table: "InstrumentItem",
                column: "iSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_MeasuredVariableId",
                table: "InstrumentItem",
                column: "MeasuredVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_MeasuredVariableModifierId",
                table: "InstrumentItem",
                column: "MeasuredVariableModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentItem_ReadoutId",
                table: "InstrumentItem",
                column: "ReadoutId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_FinishMWOItemId",
                table: "PipingItem",
                column: "FinishMWOItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_NozzleFinishId",
                table: "PipingItem",
                column: "NozzleFinishId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_NozzleStartId",
                table: "PipingItem",
                column: "NozzleStartId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_pDiameterId",
                table: "PipingItem",
                column: "pDiameterId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_pMaterialId",
                table: "PipingItem",
                column: "pMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_pPipeClassId",
                table: "PipingItem",
                column: "pPipeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_pProcessConditionId",
                table: "PipingItem",
                column: "pProcessConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_pProcessFluidId",
                table: "PipingItem",
                column: "pProcessFluidId");

            migrationBuilder.CreateIndex(
                name: "IX_PipingItem_StartMWOItemId",
                table: "PipingItem",
                column: "StartMWOItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_EquipmentItem_EquipmentItemId",
                table: "MWOItems",
                column: "EquipmentItemId",
                principalTable: "EquipmentItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_InstrumentItem_InstrumentItemId",
                table: "MWOItems",
                column: "InstrumentItemId",
                principalTable: "InstrumentItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MWOItems_PipingItem_PipingItemId",
                table: "MWOItems",
                column: "PipingItemId",
                principalTable: "PipingItem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_EquipmentItem_EquipmentItemId",
                table: "Nozzles",
                column: "EquipmentItemId",
                principalTable: "EquipmentItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_InstrumentItem_InstrumentItemId",
                table: "Nozzles",
                column: "InstrumentItemId",
                principalTable: "InstrumentItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nozzles_PipingItem_PipingItemId",
                table: "Nozzles",
                column: "PipingItemId",
                principalTable: "PipingItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PipeAccesorys_PipingItem_pPipingItemId",
                table: "PipeAccesorys",
                column: "pPipingItemId",
                principalTable: "PipingItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
